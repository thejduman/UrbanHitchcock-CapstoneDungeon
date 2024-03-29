using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    private List<string> sceneHistory = new List<string>();  //running history of scenes
                                                             //The last string in the list is always the current scene running

    //public Player player;

    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);  //Allow this object to persist between scene changes
        //sceneHistory.Add(SceneManager.GetActiveScene().name);
    }

    //Call this whenever you want to load a new scene
    //It will add the new scene to the sceneHistory list
    

    public void LoadScene(string newScene)
    {
        /*Debug.Log("Started execution of LoadScene");
        if (GameObject.FindWithTag("Player") !=  null)
        {
            Debug.Log("Pre-load check");
            GameObject.FindWithTag("Player").GetComponent<Player>().SavePosition();
        }*/
        sceneHistory.Add(newScene);
        SceneManager.LoadScene(newScene);

        for (int i = 0; i < sceneHistory.Count; i++)
        {
            Debug.Log(sceneHistory[i]);
        }

        /*if (GameObject.FindWithTag("Player") != null)
        {
            Debug.Log("Post-load check");
            GameObject.FindWithTag("Player").GetComponent<Player>().LoadPosition();
        }*/

    }

    //Call this whenever you want to load the previous scene
    //It will remove the current scene from the history and then load the new last scene in the history
    //It will return false if we have not moved between scenes enough to have stored a previous scene in the history
    public bool PreviousScene()
    {
        bool returnValue = false;
        if (sceneHistory.Count >= 2)  //Checking that we have actually switched scenes enough to go back to a previous scene
        {
            /*if (GameObject.FindWithTag("Player") != null)
            {
                GameObject.FindWithTag("Player").GetComponent<Player>().SavePosition();
            }*/
            returnValue = true;
            sceneHistory.RemoveAt(sceneHistory.Count - 1);
            SceneManager.LoadScene(sceneHistory[sceneHistory.Count - 1]);
            /*if (GameObject.FindWithTag("Player") != null)
            {
                GameObject.FindWithTag("Player").GetComponent<Player>().LoadPosition();
            }*/
        }

        return returnValue;
    }

}
//code courtesy of Joe-Censored on the Unity Forums
//https://forum.unity.com/threads/how-can-i-open-previous-scene.652507/