using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    static public ResourceManager instance = null;

    public int startFunds;

    public int Funds { get; private set; }

    // Passengers
    // First Class
    public List<FirstClassFamily> firstClass = new List<FirstClassFamily>();
    // Second Class
    // Third Class

    // Resources
    // First Class Meals
    // Second Class Meals
    // Third Class Meals
    // Ingredients

    // Tools
    // Biomass (Won from recycling, used for growing food)
    // spare parts
    // breacher suits
    // clothing
    // alcohol

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

    public void Start()
    {
        Funds = startFunds;
    }

    public bool CanAfford(int price)
    {
        return price <= Funds;
    }

    public bool Spend(int money)
    {
        if(CanAfford(money))
        {
            Funds -= money;
            return true;
        }
        return false;
    }

    public int Passengers
    {
        get
        {
            int passengers = 0;
            foreach(Family family in firstClass)
            {
                passengers += family.members.Count;
            }
            return passengers;
        }
    }
}
