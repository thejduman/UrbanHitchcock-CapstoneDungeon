using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class QuizDatabase : MonoBehaviour
{
    //the name of the database
    private string dbName = "URI=file:QuizGame.db";

    // Start is called before the first frame update
    void Start()
    {
        CreateDB();
        AddQuestion("Sample Question", "Test 1", "Test 2", "Test 3", "Test 4", 1);
        DisplayQuestions();
    }

    public void CreateDB()
    {
        //create the db connection
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            //set up an object to allow db control
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS QuestionsAndAnswers (Question VARCHAR(120), Answer1 VARCHAR(40), Answer2 VARCHAR(40), Answer3 VARCHAR(40), Answer4 VARCHAR(40), CorrectAnswer INT);";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    public void AddQuestion(string question, string answer1, string answer2, string answer3, string answer4, int correctAnswer)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                //syntax: INSERT INTO tablename (field1, field2) VALUES ('value1', 'value2');"
                command.CommandText = "INSERT INTO QuestionsAndAnswers(Question, Answer1, Answer2, Answer3, Answer4, CorrectAnswer) VALUES ('" + question + "', '" + answer1 + "', '" + answer2 + "', '" + answer3 + "', '" + answer4 + "', '" + correctAnswer + "');";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void DisplayQuestions()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

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
                        Debug.Log("Question: " + reader["Question"] + "\tAnswer1: " + reader["Answer1"] + "\tAnswer2: " + reader["Answer2"] + "\tAnswer3: " + reader["Answer3"] + "\tAnswer4: " + reader["Answer4"] + "\tCorrect Answer: " + reader["CorrectAnswer"]);
                    }
                    reader.Close();
                }
            }
            connection.Close();
        }
    }
}

  