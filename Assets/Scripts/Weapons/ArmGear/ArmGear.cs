using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmGear : MonoBehaviour {
    public int slotsCount;
    public Ability[] slots;
    public int processPower = 14;

	// Use this for initialization
	void Start () {
        foreach(Ability spell in slots)
        {
            spell.Initialize(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            ActivateSpell(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateSpell(2);
        }
    }
    void ActivateSpell(int i)
    {
        slots[i - 1].TriggerAbility();
    }
}
