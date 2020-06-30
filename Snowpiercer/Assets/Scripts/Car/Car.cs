﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Car : MonoBehaviour, IPointerClickHandler
{
    public CarData carData;
    public SpriteRenderer background;
    public SpriteRenderer foreground;
    public Transform backWheels;
    public Transform frontWheels;

    public void Setup(CarData car)
    {
        carData = car;

        Vector3 backWheelPosition = backWheels.position;
        backWheelPosition.x = car.backWheelX;
        backWheels.position = backWheelPosition;

        background.sprite = car.background;

        Vector3 frontWheelPosition = frontWheels.position;
        frontWheelPosition.x = car.frontWheelX;
        frontWheels.position = frontWheelPosition;

        foreground.sprite = car.foreground;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }
}
