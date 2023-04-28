using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DialogueResponseEvents))]

public class DialogueResponseEventsEditor : Editor
{
    // Start is called before the first frame update
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueResponseEvents responseEvents = (DialogueResponseEvents)target;

        if (GUILayout.Button("Refresh"))
        {
            responseEvents.OnValidate();
        }
    }
}


