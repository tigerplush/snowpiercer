using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PassengerData
{
    public string firstName;
    public string surname;

    public TravelClass travelClass;
    public Gender gender;

    public List<string> taskList = new List<string>();

    public PassengerData(string firstName, string surname, TravelClass travelClass)
    {
        this.firstName = firstName;
        this.surname = surname;
        this.travelClass = travelClass;

        gender = (Gender)Random.Range(0, (int)Gender.LAST_ELEMENT);
    }

    public string Name
    {
        get
        {
            return firstName + " " + surname;
        }
    }

    public override string ToString()
    {
        return firstName;
    }
}
