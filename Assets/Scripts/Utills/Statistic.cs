using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Statistic  {
    // value witrhoud any modifiers
    public float plainValue = 1.0f;
    // value if modifier == 0%
    public float baseValue = 0.0f;
    // maximum value
    public float maxValue = 1000.0f;

    // TODO: make private ( now just for showing in Unity)
    [Header("Bonuses")]
    [Range(-1,1)]
    public List<float> linearBonuses;
    [Range(-1, 1)]
    public List<float> percentModifiers;


    public Statistic(float bV=0.0f,float pV=1.0f,float mV=1000f)
    {
        baseValue = bV;
        plainValue = pV;
        maxValue = mV;
        linearBonuses = new List<float>();
        percentModifiers = new List<float>();


    }


    public float getValue()
    {

        float val = baseValue + (GetBonus(linearBonuses,0) + plainValue) * GetBonus(percentModifiers,1f);
        return Mathf.Min(val,maxValue);
    }
    public  void AddPercentModifier(float modifier)
    {
        modifier = Mathf.Clamp(modifier, -1, 1);
        percentModifiers.Add(modifier);
    }
    public void RemovePercentModifier(float modifier)
    {
        percentModifiers.Remove(modifier);
    }
    public void AddLinearBonus(float bonus)
    {
        bonus = Mathf.Clamp(bonus, -1, 1);
        
        linearBonuses.Add(bonus);
    }
    public void RemoveLinearBonus(float bonus)
    {
        linearBonuses.Remove(bonus);

    }

    float GetBonus(List<float> bonuses,float initialBonus)
    {
    
        for (int i = 0; i < bonuses.Count; i++)
            initialBonus += bonuses[i];
        return initialBonus >= 0 ? initialBonus : 0;
    }
 




}

