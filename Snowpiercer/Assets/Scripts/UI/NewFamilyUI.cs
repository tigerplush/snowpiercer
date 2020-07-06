using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFamilyUI : MonoBehaviour
{
    public GameObject newFamilyPanel;
    public Transform newFamilyContent;

    private List<FamilyInfoUI> familyPanels = new List<FamilyInfoUI>();

    private void Populate(Family[] families)
    {
        for(int i = familyPanels.Count; i < families.Length; i++)
        {
            GameObject newPanel = Instantiate(newFamilyPanel, newFamilyContent);
            FamilyInfoUI familyInfo = newPanel.GetComponent<FamilyInfoUI>();
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

    public void Enable(Family[] families)
    {
        Populate(families);
        gameObject.SetActive(true);
    }

    public void Next()
    {
        FamilyManager.instance.FinishedChoosing();
        gameObject.SetActive(false);
    }
}
