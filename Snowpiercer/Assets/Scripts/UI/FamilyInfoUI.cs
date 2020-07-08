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

    private Family family;

    public void Set(Family family)
    {
        this.family = family;
        UpdateUI();
        gameObject.SetActive(true);
    }

    public void UpdateUI()
    {
        familySurname.text = family.Surname;
        familyInfo.text = family.ToString();
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
