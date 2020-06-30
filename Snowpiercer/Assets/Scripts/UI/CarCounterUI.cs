using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarCounterUI : MonoBehaviour
{
    public Text currentCarsText;
    public Text maximumCarsText;

    private CarManager carManager;
    // Start is called before the first frame update
    void Start()
    {
        carManager = CarManager.instance;
        maximumCarsText.text = carManager.maximumNumberOfCars.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        currentCarsText.text = carManager.cars.Count.ToString();
    }
}
