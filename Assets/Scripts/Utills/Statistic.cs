using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Statistic  {

    public float baseValue = 0.0f;
    public float plainValue = 1.0f;
    public float maxValue = 1000.0f;

    public List<float> linearBonuses;
    public List<float> percentModifiers;


    Statistic()
    {
        linearBonuses = new List<float>();
        percentModifiers = new List<float>();


    }


    public float getValue()
    {
        float val = baseValue + (GetLinearBonus() + plainValue) * GetPercentModifier();
        return val > maxValue ? maxValue : val;
    }
    void AddPercentModifier(float modifier)
    {
        percentModifiers.Add(modifier);
    }
    void RemovePercentModifier(float modifier)
    {
        percentModifiers.Remove(modifier);
    }
    void AddLinearBonus(float bonus)
    {
        linearBonuses.Add(bonus);
    }
    void RemoveLinearBonus(float bonus)
    {
        linearBonuses.Remove(bonus);

    }
    float GetLinearBonus()
    {
        float linearBonus = 0;
        for (int i = 0; i < linearBonuses.Count; i++)
            linearBonus += linearBonuses[i];
        return linearBonus;
    }
    float GetPercentModifier()
    {
        float percentModifier = 1f;
        for (int i = 0; i < percentModifiers.Count; i++)
            percentModifier += percentModifiers[i];
        return percentModifier;
    }





}

