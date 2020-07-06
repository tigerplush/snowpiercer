using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Family
{
    public string Surname
    {
        get;
        private set;
    }
    public List<string> members = new List<string>();

    public Family(string surname, float[] chances)
    {
        Surname = surname;
        members.Add(Data.RandomElement(Data.FirstNames()));

        foreach(float chance in chances)
        {
            if(Random.value < chance)
            {
                members.Add(Data.RandomElement(Data.FirstNames()));
            }
        }
    }

    override public string ToString()
    {
        string infos = "";

        for(int i = 0; i < members.Count - 1; i++)
        {
            infos += members[i] + ", ";
        }

        infos += members[members.Count - 1];

        return infos;
    }
}
