using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA; //list of questions
    public GameObject[] options; //the answer buttons
    public int currentQuestion; //the current question

    int totalQuestions = 0; //number of questions in the array
    public int correctans; //number of times a question is answered correctly
    public int incorrectans; //number of times a question is answered incorrectly

    public TMPro.TextMeshProUGUI QuestionText; //game object for the question text
    public TMPro.TextMeshProUGUI CorrectText; //on screen text for the number of correct answers
    public TMPro.TextMeshProUGUI IncorrectText; //on screen text for the number of incorrect answers

    //runs at start of game
    private void Start()
    {
        totalQuestions = QnA.Count;
        generateQuestion();
    }

    //when a auestion is answered correctly
    public void correct()
    {
        correctans++;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    //when a question is answered incorrectly
    public void incorrect()
    {
        incorrectans++;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    //set the answer text on the buttons
    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++) 
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i) //setting the correct answer
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    //set the question. runs after a question is answered
    void generateQuestion()
    {
        CorrectText.text = "Correct: " + correctans;
        IncorrectText.text = "Incorrect: " + incorrectans;
        
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count); //pick a random question from the list

            //set up the quiz
            QuestionText.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of questions");
        }
        

    }
}
