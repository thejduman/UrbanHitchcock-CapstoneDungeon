using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class QuizDatabase : MonoBehaviour
{
    //the name of the database
    public string dbName = "URI=file:QuizGame.db";

    protected virtual void CreateDB()
    {
        //create the db connection
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            //set up an object to allow db control
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS QuestionsAndAnswers (Question VARCHAR(250), Answer1 VARCHAR(80), Answer2 VARCHAR(80), Answer3 VARCHAR(80), Answer4 VARCHAR(80), CorrectAnswer INT);";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    protected virtual void AddQuestion(string question, string answer1, string answer2, string answer3, string answer4, int correctAnswer)
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

    protected virtual void DisplayQuestions()
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

    protected virtual void OpenCSV(string filepath)
    {
        CreateDB();
        Debug.Log("OpenCSV:" + filepath);
        var lines = File.ReadAllLines(filepath);
        foreach (var line in lines)
        {
            var question = line.Split(';');
            //Debug.Log(question[0] + " " + question[1] + " " + question[2] + " " + question[3] + " " + question[4] + " " + question[5]);
            AddQuestion(question[0], question[1], question[2], question[3], question[4], int.Parse(question[5]));

            //Debug.Log(question[0] + " " + question[1]);
        }
    }

    protected virtual void ClearDB()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                //syntax: INSERT INTO tablename (field1, field2) VALUES ('value1', 'value2');"
                command.CommandText = "DELETE FROM QuestionsAndAnswers";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }


}

  