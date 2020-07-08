using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewFamilyUI : MonoBehaviour
{
    public GameObject newFamilyPanel;
    public Transform newFamilyContent;

    public Text selectionText;
    public Button inviteButton;

    private List<FamilyInfoUI> familyPanels = new List<FamilyInfoUI>();
    private List<FamilyInfoUI> selectedFamilyPanels = new List<FamilyInfoUI>();
    private HousingCarData carData;

    private void Populate(Family[] families)
    {
        for(int i = familyPanels.Count; i < families.Length; i++)
        {
            GameObject newPanel = Instantiate(newFamilyPanel, newFamilyContent);
            FamilyInfoUI familyInfo = newPanel.GetComponent<FamilyInfoUI>();
            familyInfo.OnClickEvent += OnSelect;
            familyPanels.Add(familyInfo);
        }

        for(int i = 0; i < familyPanels.Count; i++)
        {
            if(i < families.Length)
            {
                familyPanels[i].Set(families[i]);
            }
            else
            {
                familyPanels[i].gameObject.SetActive(false);
            }
        }
    }

    public void Enable(Family[] families, HousingCarData car)
    {
        carData = car;
        UpdateTitle();
        Populate(families);
        gameObject.SetActive(true);
    }

    public void Invite()
    {
        FamilyManager.instance.FinishedChoosing();
        gameObject.SetActive(false);
    }

    public void OnSelect(FamilyInfoUI newPanel)
    {
        //If selected, deselect
        if(selectedFamilyPanels.Contains(newPanel))
        {
            selectedFamilyPanels.Remove(newPanel);
        }
        else
        {
            selectedFamilyPanels.Add(newPanel);
        }

        //update ui
        UpdateTitle();
        foreach(FamilyInfoUI familyInfo in familyPanels)
        {
            bool selectionLeft = selectedFamilyPanels.Count < carData.maximumNumberOfOccupants;
            bool thisPanel = selectedFamilyPanels.Contains(familyInfo);
            familyInfo.interactable = selectionLeft || thisPanel;
        }

        inviteButton.interactable = selectedFamilyPanels.Count == carData.maximumNumberOfOccupants;
    }

    private void UpdateTitle()
    {
        int remainingFamilies = carData.maximumNumberOfOccupants - selectedFamilyPanels.Count;
        selectionText.text = string.Format("Pick {0} famil{1} for {2}", remainingFamilies, remainingFamilies == 1 ? "y" : "ies", carData.name);
    }
}
