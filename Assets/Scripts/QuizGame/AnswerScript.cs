using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerScript : MonoBehaviour
{
    
    public bool isCorrect = false;
    public bool isFinished = false;
    public QuizManager quizManager;
    
    //when an answer is clicked
    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizManager.incorrect();
        }
    }

    //when the continue button on the pop-up is clicked
    public void Continue() 
    {
        if (!isFinished)
        {
            if (quizManager.QnA.Count > 0 && quizManager.incorrectans < 4)
            {
                quizManager.generateQuestion();
            }
            else
            {
                if (quizManager.correctans >= 6 && quizManager.incorrectans < 4)
                {
                    quizManager.PassingGrade();
                    isFinished = true;
                }
                else if (quizManager.incorrectans >= 4)
                {
                    quizManager.FailingGrade();
                    isFinished = true;
                }

            }
        }
        else
        {
            GameObject.FindWithTag("SceneSwitcher").GetComponent<SceneChanger>().PreviousScene();
        }
        
    }
}
