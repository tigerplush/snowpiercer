using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CarManager))]
public class CarManagerEditor : Editor
{
    private string car = "";

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Separator();
        this.car = EditorGUILayout.TextField(this.car);
        if(GUILayout.Button("Add Car"))
        {
            CarManager manager = this.target as CarManager;
            manager.Buy(this.car, 1);
        }
    }
}
