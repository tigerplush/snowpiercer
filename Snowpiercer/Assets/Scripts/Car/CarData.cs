using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Cars/New Car", order = 1)]
public class CarData : ScriptableObject
{
    public string id;
    public string description;
    public int cost;

    public TravelClass travelClass;
    public CarType type;

    public float backWheelX = -1.2f;
    public float frontWheelX = 1.2f;

    public Sprite background;
    public Sprite foreground;
}
