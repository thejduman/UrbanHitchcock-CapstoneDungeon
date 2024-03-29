using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public bool GameIsPaused = false;

    public GameObject pauseMenuUI;




    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Escape))
        {
            if( GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        //inventoryUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void SaveGame()
    {
        Debug.Log("Saving Game...");
    }

    public void OpenJournal()
    {
        //SceneManager.LoadScene("Menu"); Meant to call variable when completed
        Debug.Log("Openning Journal...");
    }

    public void OpenMap()
    {
        //SceneManager.LoadScene("Map"); Meant to call a variable when completed
        Debug.Log("Opening Map...");
    }

    public void LoadMenu()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameObject.FindWithTag("SceneSwitcher").GetComponent<SceneChanger>().LoadScene("Menu"); //This is meant to call a variable for the menu
        Debug.Log("Loading Menu...");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }




}
