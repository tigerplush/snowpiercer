using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public TravelClass travelClass;
    public CarType type;

    public List<Fulfillment> fulfillments = new List<Fulfillment>();

    public virtual void Setup(CarData car)
    {
        name = car.name;
        travelClass = car.travelClass;
        type = car.type;
        fulfillments = car.fulfillments;
    }
}
