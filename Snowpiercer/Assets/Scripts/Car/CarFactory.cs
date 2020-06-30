using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFactory : MonoBehaviour
{
    static public CarFactory instance = null;

    public GameObject carPrefab;

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

    public Car Create(CarData carData)
    {
        GameObject newCar = Instantiate(carPrefab, CarManager.instance.transform);
        Car car = newCar.GetComponent<Car>();
        car.Setup(carData);
        return car;
    }
}
