using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AStarConnector))]
public class AStarConnectorEditor : Editor
{
    public AStarConnector connector = null;

    public void OnEnable()
    {
        connector = target as AStarConnector;
    }

    public void OnSceneGUI()
    {
        if(connector)
        {
            if(connector.areaA)
            {
                Vector3 pos = connector.areaA.Center + connector.pointA;
                pos = Handles.PositionHandle(pos, Quaternion.identity);
                connector.pointA = pos - connector.areaA.Center;
            }

            if (connector.areaB)
            {
                Vector3 pos = connector.areaB.Center + connector.pointB;
                pos = Handles.PositionHandle(pos, Quaternion.identity);
                connector.pointB = pos - connector.areaB.Center;
            }

            if(connector.areaA && connector.areaB)
            {
                Handles.color = Color.cyan;
                Handles.DrawLine(connector.areaA.Center + connector.pointA, connector.areaB.Center + connector.pointB);
            }
        }
    }
}
