using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Slider slider = null;
    public float updateTime = 0.5f;
    public float minLoadTime = 3.0f;
    private float time = 0.0f;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(SceneChanger.instance.StartLoad());
	}
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;
        slider.value = time;

        if(SceneChanger.instance.IsLoad())
        {
            if(float.Epsilon > minLoadTime - time)
            {
                SceneChanger.instance.SetSceneActivation();
            }
        }
    }

    public IEnumerator UpdateProgress()
    {
        while(true)
        {
            if(SceneChanger.instance.GetProgress() > slider.value)
            {
                slider.value = SceneChanger.instance.GetProgress();
            }

            yield return new WaitForSeconds(updateTime);
        }
    }
}