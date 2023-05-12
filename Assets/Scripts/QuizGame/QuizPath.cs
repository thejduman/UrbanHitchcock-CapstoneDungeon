using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class QuizPath : MonoBehaviour
{
    // This will get the current WORKING directory (i.e. \bin\Debug)
    static string workingDirectory = Environment.CurrentDirectory;
    // or: Directory.GetCurrentDirectory() gives the same result

    // This will get the current PROJECT bin directory (ie ../bin/)
    string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

    // This will get the current PROJECT directory
    //string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

    private void Start()
    {
        Debug.Log(workingDirectory);
        Debug.Log(projectDirectory);
    }
}
