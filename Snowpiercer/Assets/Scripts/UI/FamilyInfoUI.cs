using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FamilyInfoUI : Toggle
{
    public Image familyPortrait;
    public Text familySurname;
    public Text familyInfo;

    public delegate void OnClickHandler(FamilyInfoUI familyInfoUi);
    public OnClickHandler OnClickEvent;

    public Family Family
    {
        get;
        private set;
    }

    public void Set(Family family)
    {
        Family = family;
        UpdateUI();
        interactable = true;
        isOn = false;
        gameObject.SetActive(true);
    }

    public void UpdateUI()
    {
        familySurname.text = Family.Surname;
        familyInfo.text = Family.ToString();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        if(IsInteractable())
        {
            OnClickEvent?.Invoke(this);
        }
    }
}
