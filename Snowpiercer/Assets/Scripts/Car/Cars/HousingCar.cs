using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousingCar : Car
{
    public int MaximumNumberOfOccupants
    {
        get;
        private set;
    }
    public List<Family> occupants = new List<Family>();

    public int NumberOfOccupants
    {
        get
        {
            return occupants.Count;
        }
    }

    public override void Setup(CarData carData)
    {
        base.Setup(carData);
        HousingCarData car = (HousingCarData)carData;
        MaximumNumberOfOccupants = car.maximumNumberOfOccupants;
    }

    public void MoveIn(Family[] families)
    {
        occupants.AddRange(families);
    }
}
