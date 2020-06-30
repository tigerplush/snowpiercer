using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyManager : MonoBehaviour
{
    static public FamilyManager instance = null;

    public NewFamilyUI familyUi;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public IEnumerator ShowFamilySelectionDialogue()
    {
        Debug.Log("Family Selection Dialogue");
        //familyUi.Enable();
        //TaskManager.instance.NextTask();
        yield return null;
    }
}
