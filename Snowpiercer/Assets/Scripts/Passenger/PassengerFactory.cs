using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerFactory : MonoBehaviour
{
    static public PassengerFactory instance = null;

    public GameObject passengerPrefab;
    public Transform passengerParent;

    public List<Passenger> passengers = new List<Passenger>();

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

    public Passenger Instantiate(PassengerData passengerData)
    {
        GameObject passengerObject = Instantiate(passengerPrefab, passengerParent);
        Passenger passenger = passengerObject.GetComponent<Passenger>();
        passenger.Set(passengerData);
        passengers.Add(passenger);
        return passenger;
    }

    public Passenger Instantiate(HousingCar car, PassengerData passengerData)
    {
        Passenger passenger = Instantiate(passengerData);
        Vector3 position = passengerPrefab.transform.position;
        position.x = car.transform.position.x;
        passenger.transform.position = position;
        return passenger;
    }
}
