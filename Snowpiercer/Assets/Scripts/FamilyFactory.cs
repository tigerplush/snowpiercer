using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyFactory : MonoBehaviour
{
    static public FamilyFactory instance = null;

    public float[] chances;

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

    public Family Create()
    {
        Family family = new FirstClassFamily(chances);
        return family;
    }
}
