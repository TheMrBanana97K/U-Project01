using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmGear : MonoBehaviour {
    public int slotsCount;
    public Ability[] slots;
    public int processPower = 14;

	// Use this for initialization
	void Start () {
		slots = new Ability[slotsCount];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void ActivateSpell(int i)
    {
        slots[i - 1].Execute();
    }
}
