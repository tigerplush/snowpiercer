using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerFactory : MonoBehaviour
{
    static public PassengerFactory instance = null;

    public GameObject passengerPrefab;
    public Transform passengerParent;

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

    public PassengerCosmetics Instantiate()
    {
        GameObject passengerObject = Instantiate(passengerPrefab, passengerParent);
        PassengerCosmetics passengerCosmetics = passengerObject.GetComponent<PassengerCosmetics>();
        return passengerCosmetics;
    }

    public PassengerCosmetics Instantiate(HousingCar car)
    {
        PassengerCosmetics passengerCosmetics = Instantiate();
        Vector3 position = passengerPrefab.transform.position;
        position.x = car.transform.position.x;
        passengerCosmetics.transform.position = position;
        return passengerCosmetics;
    }
}
