using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstClassFamily : Family
{
    public int funds;
    public int income;

    public int Income
    {
        get
        {
            float happiness = 0f;
            foreach(Passenger member in members)
            {
                happiness += member.Happiness;
            }
            happiness /= members.Count;
            int scaledIncome = (int)(income * happiness / 100f);
            scaledIncome = Mathf.Clamp(scaledIncome, 0, income);
            return scaledIncome;
        }
    }

    public FirstClassFamily(string surname, float[] chances, Vector2 funds, Vector2 income) : base(surname, chances)
    {
        float f = Random.value;
        this.funds = Mathf.FloorToInt(funds.x + f * (funds.y - funds.x));
        this.income = Mathf.FloorToInt(income.x + (1 - f) * (income.y - income.x));
    }

    public override string ToString()
    {
        string info = base.ToString();
        info += "\nFunds: " + funds.ToString() + ", Income: " + income.ToString();
        return info;
    }
}
