using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Family
{
    public string Surname
    {
        get;
        private set;
    }
    public List<Passenger> members = new List<Passenger>();

    public Family(string surname, float[] chances)
    {
        Surname = surname;
        string firstName = Data.RandomElement(Data.FirstNames());
        members.Add(new Passenger(firstName, surname));

        foreach(float chance in chances)
        {
            if(Random.value < chance)
            {
                firstName = Data.RandomElement(Data.FirstNames());
                members.Add(new Passenger(firstName, surname));
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
