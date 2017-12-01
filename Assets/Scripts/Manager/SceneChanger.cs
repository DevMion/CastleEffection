using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance = null;
    private string loadingSceneName = "";
    private string changeSceneName = "";
    private AsyncOperation asyncOperation;

    private void Awake()
    {
        Debug.Log("Awake Scene");
        if (!instance)
        {
            Debug.Log("Dont Destroy");
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (this != instance)
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    public void SetLoadingScene(string sceneName)
    {
        loadingSceneName = sceneName;
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeLoadingScene(string sceneName)
    {
        changeSceneName = sceneName;
        ChangeScene(loadingSceneName);
    }

    public float GetProgress()
    {
        return asyncOperation.progress;
    }

    public bool IsLoad()
    {
        return (0.9f - asyncOperation.progress) < float.Epsilon;
    }

    public void SetSceneActivation()
    {
        asyncOperation.allowSceneActivation = true;
    }

    public IEnumerator StartLoad()
    {
        asyncOperation = SceneManager.LoadSceneAsync(changeSceneName);
        asyncOperation.allowSceneActivation = false;
        
        while(0.9f - asyncOperation.progress > float.Epsilon)
        {
            yield return true;
        }
    }
}