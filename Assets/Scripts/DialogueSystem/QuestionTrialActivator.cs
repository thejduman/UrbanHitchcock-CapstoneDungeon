using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class QuestionTrialActivator : QuizDatabase//, IInteractable
{
    public string csvPath;
    private string workingDirectory = Environment.CurrentDirectory;
    //private QuizDatabase qdb;

    SceneChanger sceneChanger;

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out Player player)) 
        {
            Debug.Log("Interactable");
            player.Interactable = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out Player player))
        {
            if (player.Interactable is QuestionTrialActivator questionTrialActivator && questionTrialActivator == this)
            {
                Debug.Log("Not interactable");
                player.Interactable = null;
            }
        }
    }*/

    public void Interact()
    {
        //Debug.Log("Change scene");
        //qdb.OpenCSV(csvPath);
        CreateDB();
        ClearDB();
        Debug.Log("Interact: " + workingDirectory + csvPath);
        OpenCSV(workingDirectory + csvPath);
        GameObject.FindWithTag("SceneSwitcher").GetComponent<SceneChanger>().LoadScene("QuizGame");
        
        //scenes.LoadScene("QuizGame");
    }
}
