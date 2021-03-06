﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyFactory : MonoBehaviour
{
    static public FamilyFactory instance = null;

    public float[] chances;

    public Vector2 firstClassFunds;
    public Vector2 firstClassIncome;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public Family CreateOne(TravelClass travelClass)
    {
        Family family = null;
        string surname = Data.RandomElement(Data.surnames);
        switch(travelClass)
        {
            case TravelClass.First:
                family = new FirstClassFamily(surname, chances, firstClassFunds, firstClassIncome);
                break;
            case TravelClass.Second:
                break;
            case TravelClass.Third:
                break;
        }
        return family;
    }

    public Family[] Create(TravelClass travelClass, int numberOfFamilies)
    {
        List<Family> families = new List<Family>();
        for(int i = 0; i < numberOfFamilies; i++)
        {
            families.Add(CreateOne(travelClass));
        }
        return families.ToArray();
    }
}
