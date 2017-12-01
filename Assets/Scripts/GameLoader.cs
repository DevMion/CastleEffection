using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public GameManager gameManager = null;
    public SoundManager soundManager = null;
    public SceneChanger sceneChanger = null;
    public DisplayFPS displayFPS = null;

    private void Awake()
    {
        Debug.Log("Game Load");
        if(gameManager && !GameManager.instance)
        {
            Debug.Log("new Game");
            Instantiate(gameManager);
        }
        if (soundManager && !SoundManager.instance)
        {
            Debug.Log("new Sound");
            Instantiate(soundManager);
        }
        if (sceneChanger && !SceneChanger.instance)
        {
            Debug.Log("new Scene");
            Instantiate(sceneChanger);
        }
        if (displayFPS && !DisplayFPS.instance)
        {
            Debug.Log("new FPS");
            Instantiate(displayFPS);
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
}
