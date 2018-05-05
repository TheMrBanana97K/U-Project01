﻿using System.Collections;
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
    public List<float> linearBonuses;
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

        float val = baseValue + (GetLinearBonus() + plainValue) * GetPercentModifier();
        return Mathf.Min(val,maxValue);
    }
    public  void AddPercentModifier(float modifier)
    {
        percentModifiers.Add(modifier);
    }
    public void RemovePercentModifier(float modifier)
    {
        percentModifiers.Remove(modifier);
    }
    public void AddLinearBonus(float bonus)
    {
        linearBonuses.Add(bonus);
    }
    public void RemoveLinearBonus(float bonus)
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

