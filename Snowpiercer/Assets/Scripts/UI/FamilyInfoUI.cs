using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FamilyInfoUI : Selectable
{
    public Image familyPortrait;
    public Text familySurname;
    public Text familyInfo;

    public delegate void OnSelectHandler(Family family);
    public OnSelectHandler OnSelectEvent;

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
        if (this.IsInteractable())
        {
            EventSystem.current.SetSelectedGameObject(null);
            this.Select();
            OnSelectEvent?.Invoke(this.family);
        }
    }
}
