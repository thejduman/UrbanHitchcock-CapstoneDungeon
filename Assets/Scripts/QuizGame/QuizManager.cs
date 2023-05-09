using Mono.Data.Sqlite;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : QuizDatabase
{
    public List<QuestionsAndAnswers> QnA; //list of questions
    public GameObject[] options; //the answer buttons
    public int currentQuestion; //the current question

    int totalQuestions = 0; //number of questions in the array
    public int correctans; //number of times a question is answered correctly
    public int incorrectans; //number of times a question is answered incorrectly
    public bool isFail = false;

    public TMPro.TextMeshProUGUI QuestionText; //game object for the question text
    public TMPro.TextMeshProUGUI CorrectText; //on screen text for the number of correct answers
    public TMPro.TextMeshProUGUI IncorrectText; //on screen text for the number of incorrect answers

    public GameObject StatusPanel;
    public TMPro.TextMeshProUGUI StatusText;

    
    public QuestionsAndAnswers questions;

    //runs at start of game
    private void Start()
    {
        //CreateDB();
        //ClearDB();
        //OpenCSV(csvPath);
        //DisplayQuestions();
        SetQnA();
        totalQuestions = QnA.Count;
        generateQuestion();
    }

    //when a auestion is answered correctly
    public void correct()
    {
        correctans++;
        StatusText.text = "Correct Answer";
        StatusPanel.SetActive(true);
        QnA.RemoveAt(currentQuestion);
    }

    //when a question is answered incorrectly
    public void incorrect()
    {
        incorrectans++;
        StatusText.text = "Incorrect Answer";
        StatusPanel.SetActive(true);
        QnA.RemoveAt(currentQuestion);
    }

    public void PassingGrade()
    {
        Debug.Log("You passed!");
        StatusText.text = "You passed!";
        StatusPanel.SetActive(true);
    }

    public void FailingGrade()
    {
        Debug.Log("You failed...");
        isFail = true;
        StatusText.text = "You failed...";
        StatusPanel.SetActive(true);
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
    public void generateQuestion()
    {
        CorrectText.text = "Correct: " + correctans;
        IncorrectText.text = "Incorrect: " + incorrectans;
        StatusPanel.SetActive(false);

        if (QnA.Count > 0)
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

    public void SetQnA()
    {
        QnA.Clear();
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            string[] tempArray = {"One", "Two", "Three", "Four" };
            string temp = "Test Question";
            int tempNum = 0;
            


            using (var command = connection.CreateCommand())
            {
                //select what you want to get
                //this just sets the parameters of what will be returned
                command.CommandText = "SELECT * FROM QuestionsAndAnswers;";

                //iterate through the recordset that was returned from the statement above
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        questions = new QuestionsAndAnswers();
                        tempArray = new string[4];

                        temp = reader["Question"] as string;
                        questions.question = temp;

                        
                        tempArray[0] = reader["Answer1"] as string;
                        tempArray[1] = reader["Answer2"] as string;
                        tempArray[2] = reader["Answer3"] as string;
                        tempArray[3] = reader["Answer4"] as string;

                        
                        questions.answers = tempArray;
                        
                        
                        
                        temp = reader["CorrectAnswer"].ToString();
                        tempNum = int.Parse(temp);
                        questions.correctanswer = tempNum;
                        

                        QnA.Add(questions);

                        

                    }
                    


                    reader.Close();

                    

                }
            }
            connection.Close();

        }
    }
}
