using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFamilyUI : MonoBehaviour
{
    public GameObject newFamilyPanel;
    public Transform newFamilyContent;

    private List<GameObject> familyPanels = new List<GameObject>();

    private void Populate(GameObject[] passengers)
    {
        for(int i = familyPanels.Count; i < passengers.Length; i++)
        {
            GameObject newPanel = Instantiate(newFamilyPanel, newFamilyContent);
            familyPanels.Add(newPanel);
        }

        for(int i = 0; i < familyPanels.Count; i++)
        {
            if(i < passengers.Length)
            {
                familyPanels[i].SetActive(true);
            }
            else
            {
                familyPanels[i].SetActive(false);
            }
        }
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }
}
