using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionTrialActivator : MonoBehaviour, IInteractable
{
    public string csvPath;
    private QuizDatabase qdb;

    private void OnTriggerEnter2D(Collider2D other)
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
    }

    public void Interact(Player player)
    {
        //Debug.Log("Change scene");
        qdb.OpenCSV(csvPath);
        SceneManager.LoadScene("QuizGame");
    }
}
