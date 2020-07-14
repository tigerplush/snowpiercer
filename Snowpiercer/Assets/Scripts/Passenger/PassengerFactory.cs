using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerFactory : MonoBehaviour
{
    static public PassengerFactory instance = null;

    public GameObject passengerPrefab;
    public Transform passengerParent;

    public List<Passenger> passengers = new List<Passenger>();

    public delegate void OnUpdateHandler();
    public OnUpdateHandler OnUpdate;

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

    public PassengerCosmetics Instantiate(Passenger passenger)
    {
        GameObject passengerObject = Instantiate(passengerPrefab, passengerParent);
        PassengerCosmetics passengerCosmetics = passengerObject.GetComponent<PassengerCosmetics>();
        passengers.Add(passenger);
        OnUpdate += passenger.Update;
        return passengerCosmetics;
    }

    public PassengerCosmetics Instantiate(HousingCar car, Passenger passenger)
    {
        PassengerCosmetics passengerCosmetics = Instantiate(passenger);
        Vector3 position = passengerPrefab.transform.position;
        position.x = car.transform.position.x;
        passengerCosmetics.transform.position = position;
        return passengerCosmetics;
    }

    public void Update()
    {
        OnUpdate?.Invoke();
    }
}
