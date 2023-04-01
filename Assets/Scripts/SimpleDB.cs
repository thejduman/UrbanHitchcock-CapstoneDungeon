using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class SimpleDB : MonoBehaviour
{
    //the name of the database
    private string dbName = "URI=file:Inventory.db";

    // Start is called before the first frame update
    void Start()
    {
        CreateDB();
        AddWeapon("Silver Sword", 30);
        DisplayWeapons();
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
                //create a table called weapons if it doesn't exist already
                //it has 2 fields: name (up to 20 characters) and damage (an integer)
                command.CommandText = "CREATE TABLE IF NOT EXISTS weapons (name VARCHAR(20), damage INT);";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    public void AddWeapon(string weaponName, int weaponDamage)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                //syntax: INSERT INTO tablename (field1, field2) VALUES ('value1', 'value2');"
                command.CommandText = "INSERT INTO weapons(name, damage) VALUES ('" + weaponName + "', '" + weaponDamage + "');";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void DisplayWeapons()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                //select what you want to get
                //this just sets the parameters of what will be returned
                command.CommandText = "SELECT * FROM weapons;";

                //iterate through the recordset that was returned from the statement above
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log("Name: " + reader["name"] + "\tDamage: " + reader["damage"]);
                    }
                    reader.Close();
                }
            }
            connection.Close();
        }
    }
}

  