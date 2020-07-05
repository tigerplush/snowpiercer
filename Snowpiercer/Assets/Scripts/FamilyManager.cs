using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyManager : MonoBehaviour
{
    static public FamilyManager instance = null;

    public NewFamilyUI familyUi;

    public bool ChoosingFamily
    {
        get;
        private set;
    }


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

    public void FinishedChoosing()
    {
        ChoosingFamily = false;
    }

    public IEnumerator ShowFamilySelectionDialogue()
    {
        Debug.Log("Family selection dialogue");
        // If there is an empty Car
        if(CarManager.instance.HasOpenCar())
        {
            ChoosingFamily = true;
            HousingCarData car = CarManager.instance.GetOpenCar();
            if(car)
            {
                // Create enough families
                Family[] families = FamilyFactory.instance.Create(car.travelClass, 4);
                foreach(Family family in families)
                {
                    Debug.Log(family);
                }

                // Pass them to the UI

                familyUi.Enable();
                // While selection dialoge is open
                while (ChoosingFamily)
                {
                    yield return null;
                }
            }
        }
    }
}
