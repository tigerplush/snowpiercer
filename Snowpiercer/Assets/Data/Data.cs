using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    static public string[] maleNames =
    {
        "Liam"
        ,"Noah"
        ,"William"
        ,"James"
        ,"Oliver"
    };

    static public string[] femaleNames =
     {
        "Emma"
        ,"Olivia"
        ,"Ava"
        ,"Isabelle"
        ,"Sophia"
    };

    static public string[] otherNames =
     {
        "Alex"
        ,"Blake"
        ,"Drew"
        ,"Taylor"
        ,"Kennedy"
    };

    static public string[] surnames =
     {
        "Smith"
        ,"Johnson"
        ,"Williams"
        ,"Brown"
        ,"Jones"
    };

    static public string[] traits =
     {
        "Lazy"
        ,"Studious"
        ,"Generous"
        ,"Loyal"
    };

    static public string RandomElement(string[] field)
    {
        int random = Random.Range(0, field.Length);
        return field[random];
    }

    static public string[] FirstNames()
    {
        List<string> firstNames = new List<string>();
        firstNames.AddRange(maleNames);
        firstNames.AddRange(femaleNames);
        firstNames.AddRange(otherNames);
        return firstNames.ToArray();
    }
}
