using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    
    public bool isCorrect = false;
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
        if (quizManager.QnA.Count > 0) 
        {
            quizManager.generateQuestion();
        }
        else
        {
            Debug.Log("Change scenes"); //will transition back to the overworld
        }
        
    }
}
