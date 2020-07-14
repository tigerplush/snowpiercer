using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Need
{
    NO_TASK,
    Eat,
    Sleep,
    Wash,
    LAST_ELEMENT
}

public class Passenger : MonoBehaviour
{
    public string firstName;
    public string surname;

    public TravelClass travelClass;
    public Gender gender;

    public float Happiness = 0f;
    public float Hunger = 100f;
    public float Hygiene = 100f;

    public List<Need> taskList = new List<Need>();
    public Need currentTask = Need.NO_TASK;

    public void Set(PassengerData data)
    {
        firstName = data.firstName;
        surname = data.surname;
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

        if (Hunger < 0f && !taskList.Contains(Need.Eat))
        {
            //Add eating to task list
            taskList.Add(Need.Eat);
        }

        if (Hygiene < 0f && !taskList.Contains(Need.Wash))
        {
            //add washing to task list
            taskList.Add(Need.Wash);
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
            //No task => Idle
        }
        else if(currentTask != Need.NO_TASK)
        {
            //Active task => poll if fulfilled
        }
        else
        {
            //Check each task
            foreach(Need task in taskList)
            {
                //Find cars that can fulfill the need
                List<Car> elegibleCars = CarManager.instance.FindCar(task, travelClass);
                Debug.Log(string.Format("{0} can fullfill need {1}", elegibleCars.Count, task));

                //Sort after how good they fulfill the need

                //Check if car is reachable

                //Set target

                //break
            }

            //if no task can be fulfilled
            //passenger will be frustrated
        }
    }
}
