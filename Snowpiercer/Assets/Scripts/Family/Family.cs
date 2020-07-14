using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Family
{
    [SerializeField]
    public string Surname
    {
        get;
        private set;
    }

    public List<PassengerData> blueprints = new List<PassengerData>();
    public List<Passenger> members = new List<Passenger>();

    public Dictionary<PassengerData, Relation> relations = new Dictionary<PassengerData, Relation>();

    public enum Relation
    {
        P,
        P_SPOUSE,
        P_SIBLING,
        F0,
        F0_SPOUSE,
        F0_SIBLING,
        F1,
        LAST_ELEMENT
    };

    public Family(string surname, float[] chances)
    {
        Surname = surname;
        string firstName = Data.RandomElement(Data.FirstNames());
        PassengerData passenger = new PassengerData(firstName, surname);
        blueprints.Add(passenger);

        List<Relation> possibleRelations = new List<Relation>();
        for(int i = 0; i < (int)Relation.LAST_ELEMENT; i++)
        {
            possibleRelations.Add((Relation)i);
        }

        Relate(passenger, possibleRelations);

        foreach(float chance in chances)
        {
            if(Random.value < chance)
            {
                firstName = Data.RandomElement(Data.FirstNames());
                passenger = new PassengerData(firstName, surname);
                blueprints.Add(passenger);
                Relate(passenger, possibleRelations);
            }
        }
    }

    private void Relate(PassengerData passenger, List<Relation> remainingRelations)
    {
        Relation relation = (Relation)Random.Range(0, remainingRelations.Count);

        relations.Add(passenger, relation);
        if(
            relation == Relation.P ||
            relation == Relation.P_SPOUSE ||
            relation == Relation.F0 ||
            relation == Relation.F0_SPOUSE
            )
        {
            remainingRelations.Remove(relation);
        }
    }

    override public string ToString()
    {
        string infos = "";

        for(int i = 0; i < blueprints.Count - 1; i++)
        {
            infos += blueprints[i] + ", ";
        }

        infos += blueprints[blueprints.Count - 1];

        return infos;
    }
}
