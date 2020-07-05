using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    static public CarManager instance = null;

    public NewCarUI newCarUi;

    public CarData firstCar;
    public int maximumNumberOfCars = 1001;
    public List<Car> cars = new List<Car>();
    public List<CarData> availableCars = new List<CarData>();

    public float carLength = 4f;

    public bool ChoosingCar
    {
        get;
        private set;
    }

    private CarData nextCar = null;
    private int placement;

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

    public void Start()
    {
        Car newCar = CarFactory.instance.Create(firstCar);
        this.cars.Add(newCar);

        //TimeManager.instance.TimeUp += AddCar;
    }

    public bool Buy(string carId, int placement)
    {
        CarData carToBuy = this.availableCars.Find(item => item.id == carId);
        if(carToBuy != null && ResourceManager.instance.CanAfford(carToBuy.cost))
        {
            this.nextCar = carToBuy;
            this.placement = placement;
            return ResourceManager.instance.Spend(carToBuy.cost);
        }
        return false;
    }

    public void FinishedBuying()
    {
        ChoosingCar = false;
    }

    public bool HasOpenCar()
    {
        Debug.Log("Checking for open cars");
        List<Car> sleepCars = cars.FindAll(element => element.carData.type == CarType.Housing);
        Debug.Log(sleepCars.Count + " cars are housing");
        int familySpaces = 0;
        int occupiedSpaces = 0;
        sleepCars.ForEach(element =>
        {
            HousingCarData housingCar = (HousingCarData)element.carData;
            familySpaces += housingCar.maximumNumberOfOccupants;
            occupiedSpaces += housingCar.occupants.Count;
        });
        return occupiedSpaces < familySpaces;
    }

    public HousingCarData GetOpenCar()
    {
        Car sleepCar = cars.Find(element => element.carData.type == CarType.Housing);
        HousingCarData housingCar = (HousingCarData)sleepCar.carData;
        return housingCar;
    }

    public IEnumerator AddCar()
    {
        Debug.Log("Adding Car");
        if (nextCar != null)
        {
            Car newCar = CarFactory.instance.Create(nextCar);
            this.cars.Insert(placement, newCar);
            for(int i = 0; i < this.cars.Count; i++)
            {
                Vector3 position = this.cars[i].gameObject.transform.position;
                position.x = -carLength * i;
                this.cars[i].gameObject.transform.position = position;
            }

            nextCar = null;
        }
        yield return null;
    }

    public IEnumerator ShowCarSelectionDialogue()
    {
        ChoosingCar = true;
        Debug.Log("Car Selection Dialogue");
        newCarUi.Show();
        while(ChoosingCar)
        {
            yield return null;
        }
    }
}
