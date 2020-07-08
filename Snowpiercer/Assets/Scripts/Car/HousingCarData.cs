using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Cars/New Housing Car", order = 2)]
public class HousingCarData : CarData
{
    public int maximumNumberOfOccupants;
    public List<Family> occupants = new List<Family>();

    public int NumberOfOccupants
    {
        get
        {
            return occupants.Count;
        }
    }

    public HousingCarData()
    {
        type = CarType.Housing;
    }

    public void MoveIn(Family[] families)
    {
        occupants.AddRange(families);
    }
}
