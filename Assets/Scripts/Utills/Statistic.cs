using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Statistic  {
    // value witrhoud any modifiers
    public float plainValue = 1.0f;
    // value if modifier == 0%
     float baseValue = 0.0f;
    // maximum value
    float maxTotalValue = 1000.0f;
    float maxValue = 1000.0f;

    // TODO: make private ( now just for showing in Unity)
    [Header("Bonuses")]
    public List<float> linearBonuses;
    [Range(-1, 1)]
    public List<float> percentModifiers;


    public Statistic(float bV=0.0f,float pV=1.0f,float mV=1000f)
    {
        baseValue = bV;
        plainValue = pV;
        maxValue = pV;
        maxTotalValue = mV;
        linearBonuses = new List<float>();
        percentModifiers = new List<float>();


    }

   
    public float getValue()
    {
        plainValue = Mathf.Min(plainValue, getMaxValue());

        float val = baseValue + (GetBonus(linearBonuses,0,true) + plainValue) * GetBonus(percentModifiers,1f);
        return Mathf.Min(val,getMaxValue());
    }
    private float getMaxValue()
    {
        float val = baseValue + (GetBonus(linearBonuses, 0, true) + maxValue) * GetBonus(percentModifiers, 1f);
        return Mathf.Min(val, maxTotalValue); ;
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
    public void AddLinearBonus(float modifier)
    {
        
        linearBonuses.Add(modifier);
    }
    public void RemoveLinearBonus(float modifier)
    {
        modifier = Mathf.Clamp(modifier, -100, 100);

        linearBonuses.Remove(modifier);

    }

    float GetBonus(List<float> bonuses,float initialBonus,bool canBeNegative=false)
    {
    
        for (int i = 0; i < bonuses.Count; i++)
            initialBonus += bonuses[i];
        if (canBeNegative)
            return initialBonus;
        else
        return initialBonus >= 0 ? initialBonus : 0;
    }
 




}

