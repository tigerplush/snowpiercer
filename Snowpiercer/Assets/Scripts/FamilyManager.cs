using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyManager : MonoBehaviour
{
    static public FamilyManager instance = null;

    public NewFamilyUI familyUi;

    public List<Family> passengers = new List<Family>();

    public int Passengers
    {
        get
        {
            int passengerCount = 0;
            foreach(Family family in passengers)
            {
                passengerCount += family.members.Count;
            }
            return passengerCount;
        }
    }

    public bool ChoosingFamily
    {
        get;
        private set;
    }

    private HousingCar car;

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

    public void FinishedChoosing(Family[] families)
    {
        passengers.AddRange(families);
        car.MoveIn(families);

        foreach(Family family in families)
        {
            FirstClassFamily firstClassFamily = (FirstClassFamily)family;
            if(firstClassFamily != null)
            {
                ResourceManager.instance.Income(firstClassFamily.funds);
            }
        }

        ChoosingFamily = false;
    }

    public IEnumerator ShowFamilySelectionDialogue()
    {
        // If there is an empty Car
        if(CarManager.instance.HasOpenCar())
        {
            ChoosingFamily = true;
            car = CarManager.instance.GetOpenCar();
            if(car)
            {
                // Create enough families
                Family[] families = FamilyFactory.instance.Create(car.travelClass, 4);
                // Pass them to the UI

                familyUi.Enable(families, car);
                // While selection dialoge is open
                while (ChoosingFamily)
                {
                    yield return null;
                }

                car = null;
            }
        }
    }
}
