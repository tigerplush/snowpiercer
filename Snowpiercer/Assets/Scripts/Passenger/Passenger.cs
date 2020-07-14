using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Passenger
{
    public string firstName;
    public string surname;

    public TravelClass travelClass;
    public Gender gender;

    public float Happiness = 0f;
    public float Hunger = 100f;
    public float Hygiene = 100f;

    public Passenger(string firstName, string surname)
    {
        this.firstName = firstName;
        this.surname = surname;

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

    public void Update()
    {
        UpdateNeeds();
    }

    private void UpdateNeeds()
    {
        Hunger -= Time.deltaTime;
        Hunger = Mathf.Clamp(Hunger, -100f, 100f);

        Hygiene -= Time.deltaTime;
        Hygiene = Mathf.Clamp(Hygiene, -100f, 100f);

        if (Hunger < 0f)
        {
            //If eating not in task list
            //Add eating to task list
        }

        if (Hygiene < 0f)
        {
            //If washing not in task list
            //add washing to task list
        }

        if (Hunger < 0f || Hygiene < 0f)
        {
            Happiness -= Time.deltaTime;
        }
        else
        {
            Happiness += Time.deltaTime;
        }
        Happiness = Mathf.Clamp(Happiness, -100f, 100f);
    }
}
