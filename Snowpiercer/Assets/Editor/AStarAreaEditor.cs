using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.IMGUI.Controls;

[CustomEditor(typeof(AStarArea))]
public class AStarAreaEditor : Editor
{
    AStarArea area;
    private BoxBoundsHandle boundsHandle = new BoxBoundsHandle();

    public void OnEnable()
    {
        area = target as AStarArea;
    }

    public void OnSceneGUI()
    {
        Handles.color = Color.green;

        Transform transform = area.transform;
        //bottom line
        Handles.DrawLine(transform.position + new Vector3(area.area.x, area.area.y, 0f), transform.position + new Vector3(area.area.x + area.area.width, area.area.y, 0f));
        //upper line
        Handles.DrawLine(transform.position + new Vector3(area.area.x, area.area.y + area.area.height, 0f), transform.position + new Vector3(area.area.x + area.area.width, area.area.y + area.area.height, 0f));
        //left line
        Handles.DrawLine(transform.position + new Vector3(area.area.x, area.area.y, 0f), transform.position + new Vector3(area.area.x, area.area.y + area.area.height, 0f));
        Handles.DrawLine(transform.position + new Vector3(area.area.x + area.area.width, area.area.y, 0f), transform.position + new Vector3(area.area.x + area.area.width, area.area.y + area.area.height, 0f));

        //boundsHandle.center = area.Center;
        //boundsHandle.size = area.area.size;

        //EditorGUI.BeginChangeCheck();
        //boundsHandle.DrawHandle();
        //if(EditorGUI.EndChangeCheck())
        //{
        //    Undo.RecordObject(area, "Change AStarArea");

        //    Rect newRect = new Rect();
        //    newRect.center = boundsHandle.center;
        //    newRect.size = boundsHandle.size;
        //    area.area = newRect;
        //}
    }
}
