using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CarInfoUI : /*MonoBehaviour,*/ Selectable /*,IPointerClickHandler*/
{
    public Image carSpriteImage;
    public Text carNameText;
    public Text carDescriptionText;
    public Text carCostText;

    public delegate void OnSelectHandler(CarData car);
    public OnSelectHandler OnSelectEvent;

    private CarData car;

    public void Set(CarData car)
    {
        this.car = car;
        this.UpdateUI();
        this.gameObject.SetActive(true);
    }

    public void UpdateUI()
    {
        this.carNameText.text = car.name;
        this.carDescriptionText.text = car.description;
        this.carCostText.text = car.cost.ToString();
        this.interactable = car.cost <= ResourceManager.instance.Funds;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        if(this.IsInteractable())
        {
            EventSystem.current.SetSelectedGameObject(null);
            this.Select();
            OnSelectEvent?.Invoke(this.car);
        }
    }

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    Debug.Log("clicked " + this.carNameText.text);
    //}
}
