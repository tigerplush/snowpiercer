using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerUI : MonoBehaviour
{
    private CarData car;
    private Camera cam;
    // Update is called once per frame
    void Update()
    {
        float carLength = CarManager.instance.carLength;
        // calc screen pos to world pos
        Vector3 worldPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        // clamp/floor world pos
        int id = Mathf.CeilToInt(-worldPosition.x / carLength);
        id = Mathf.Clamp(id, 1, CarManager.instance.cars.Count);
        worldPosition.x = -(float)id * carLength + carLength / 2f;
        // calc world pos to screen pos
        Vector3 screenPosition = cam.WorldToScreenPoint(worldPosition);

        Vector3 position = transform.position;
        position.x = screenPosition.x;
        transform.position = position;

        if(Input.GetMouseButtonDown(0))
        {
            CarManager.instance.Buy(car.id, id);
            CarManager.instance.FinishedBuying();
            gameObject.SetActive(false);
        }
    }

    public void Set(CarData car)
    {
        this.car = car;
        gameObject.SetActive(true);
    }

    public void OnEnable()
    {
        cam = Camera.main;
    }
}
