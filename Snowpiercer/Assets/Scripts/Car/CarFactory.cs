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
        CarCosmetics carCosmetics = newCar.GetComponent<CarCosmetics>();
        carCosmetics.Setup(carData);
        Car car = null;
        switch(carData.type)
        {
            case CarType.Housing:
                car = newCar.AddComponent<HousingCar>();
                break;
            default:
                car = newCar.AddComponent<Car>();
                break;
        }
        car.Setup(carData);
        return car;
    }
}
