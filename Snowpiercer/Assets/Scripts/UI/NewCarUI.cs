using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewCarUI : MonoBehaviour
{
    public GameObject remainingTime;

    public Button orderButton;
    public Text orderButtonText;
    public GameObject carInfoPanel;
    public Transform carInfoContent;

    public PointerUI pointer;

    private CarManager carManager;
    private List<CarInfoUI> carInfoPanels = new List<CarInfoUI>();

    private CarData selectedCar;

    // Start is called before the first frame update
    public void Start()
    {
        carManager = CarManager.instance;
        if (carManager)
        {
            Populate();
        }
    }

    public void OnEnable()
    {
        selectedCar = null;
        if (carManager)
        {
            Populate();
        }
    }

    public void Buy()
    {
        if(selectedCar != null)
        {
            pointer.Set(selectedCar);
            this.gameObject.SetActive(false);
        }
    }

    public void SelectedButton(CarData car)
    {
        selectedCar = car;
        if(selectedCar == null)
        {
            orderButton.interactable = false;
            orderButtonText.text = "Order";
        }
        else if (selectedCar.cost <= ResourceManager.instance.Funds)
        {
            orderButton.interactable = true;
            orderButtonText.text = "Buy car";
        }
        else
        {
            orderButton.interactable = false;
            orderButtonText.text = "Insufficient funds";
        }
    }

    private void Populate()
    {
        if (carManager.availableCars.Count > carInfoPanels.Count)
        {
            for (int i = carInfoPanels.Count; i < carManager.availableCars.Count; i++)
            {
                GameObject temporaryPanel = Instantiate(carInfoPanel, carInfoContent);
                CarInfoUI temporaryCarInfoUi = temporaryPanel.GetComponent<CarInfoUI>();
                temporaryCarInfoUi.OnSelectEvent += SelectedButton;
                carInfoPanels.Add(temporaryCarInfoUi);
            }
        }

        for (int i = 0; i < carInfoPanels.Count; i++)
        {
            if (i < carManager.availableCars.Count)
            {
                carInfoPanels[i].Set(carManager.availableCars[i]);
            }
            else
            {
                carInfoPanels[i].gameObject.SetActive(false);
            }
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
        remainingTime.SetActive(true);
    }
}
