using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Slider slider = null;
    public SceneChanger sceneChanger = null;
    public float updateTime = 0.5f;
    public float minLoadTime = 3f;
    private float time = 0f;

	// Use this for initialization
	void Start ()
    {
		if(sceneChanger)
        {
            StartCoroutine(sceneChanger.StartLoad());
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;
        slider.value = time;

        if(sceneChanger.IsLoad())
        {
            if(float.Epsilon > minLoadTime - time)
            {
                sceneChanger.SetSceneActivation();
            }
        }
    }

    public IEnumerator UpdateProgress()
    {
        while(true)
        {
            if(sceneChanger.GetProgress() > slider.value)
            {
                slider.value = sceneChanger.GetProgress();
            }

            yield return new WaitForSeconds(updateTime);
        }
    }
}