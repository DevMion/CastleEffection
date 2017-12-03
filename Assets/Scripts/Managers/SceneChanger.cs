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
    private Scene nowScene = null;

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
        SetDefaultScene();
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    private void SetDefaultScene()
    {
        SetScene(SceneManager.GetActiveScene().name);
        InitScene();
    }

    private void SetScene(string sceneName)
    {
        if("Title" == sceneName)
        {
            instance.nowScene = instance.gameObject.AddComponent<TitleScene>();
        }
        else if("Game" == sceneName)
        {
            instance.nowScene = instance.gameObject.AddComponent<GameScene>();
        }
        else if ("Training" == sceneName)
        {
            instance.nowScene = instance.gameObject.AddComponent<TrainingScene>();
        }
    }

    private void InitScene()
    {
        if(instance.nowScene)
        {
            instance.nowScene.Init();
        }
    }

    private void ReleaseScene()
    {
        if(instance.nowScene)
        {
            instance.nowScene.Release();
            Destroy(instance.nowScene);
            instance.nowScene = null;
        }
    }

    public void SetLoadingScene(string sceneName)
    {
        instance.loadingSceneName = sceneName;
    }

    public void ChangeScene(string sceneName)
    {
        ReleaseScene();

        SceneManager.LoadScene(sceneName);

        SetScene(sceneName);
        InitScene();
    }

    public void ChangeLoadingScene(string sceneName)
    {
        ReleaseScene();

        instance.changeSceneName = sceneName;
        ChangeScene(instance.loadingSceneName);
    }

    public float GetProgress()
    {
        return instance.asyncOperation.progress;
    }

    public bool IsLoad()
    {
        return (0.9f - instance.asyncOperation.progress) < float.Epsilon;
    }

    public void SetSceneActivation()
    {
        instance.asyncOperation.allowSceneActivation = true;
    }

    public IEnumerator StartLoad()
    {
        instance.asyncOperation = SceneManager.LoadSceneAsync(instance.changeSceneName);
        instance.asyncOperation.allowSceneActivation = false;
        
        while(0.9f - instance.asyncOperation.progress > float.Epsilon)
        {
            yield return true;
        }

        SetScene(instance.changeSceneName);
        InitScene();
    }
}