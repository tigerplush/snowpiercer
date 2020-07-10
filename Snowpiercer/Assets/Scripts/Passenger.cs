using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger
{
    public string firstName;
    public string surname;

    public Passenger(string firstName, string surname)
    {
        this.firstName = firstName;
        this.surname = surname;
    }

    public override string ToString()
    {
        return firstName + " " + surname;
    }
}
