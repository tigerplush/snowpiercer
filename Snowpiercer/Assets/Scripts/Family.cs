using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Family
{
    public List<string> members = new List<string>();

    public Family(float[] chances)
    {
        members.Add(Data.RandomElement(Data.FirstNames()));

        foreach(float chance in chances)
        {
            if(Random.value < chance)
            {
                members.Add(Data.RandomElement(Data.FirstNames()));
            }
        }
    }
}
