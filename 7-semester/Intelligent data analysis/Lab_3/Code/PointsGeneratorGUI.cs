using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(PointsGenerator))]
public class PointsGeneratorGUI : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();


        GUILayout.BeginHorizontal();

        if(GUILayout.Button("FileExplorer"))
            ((PointsGenerator)target).OpenFileExplorer();

        if (GUILayout.Button("Generate"))
            ((PointsGenerator)target).Generate();

        GUILayout.EndHorizontal();
    }
}
