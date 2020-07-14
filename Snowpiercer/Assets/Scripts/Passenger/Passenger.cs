using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    public string firstName;
    public string surname;

    public TravelClass travelClass;
    public Gender gender;

    public float Happiness = 0f;
    public float Hunger = 100f;
    public float Hygiene = 100f;

    public List<string> taskList = new List<string>();

    public void Set(PassengerData data)
    {
        this.firstName = data.firstName;
        this.surname = data.surname;
        gender = data.gender;
        travelClass = data.travelClass;
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateNeeds();

        UpdateTasks();
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

    private void UpdateTasks()
    {
        if (taskList.Count == 0)
        {
            //Idle
        }
        else
        {
            //Check first task
            //If task can be fulfilled, begin
            //if not, check next task
        }
    }
}
