using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("Player Stats")]
    public Statistic health=new Statistic(0f,100f,1000f);
    public Statistic speed=new Statistic(1f,10f,100f);
    public Statistic energy=new Statistic(10f,100f,1000f);

    // On Death Event
    public event System.Action OnDeath;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (health.getValue() <= 0)
        {
            if (OnDeath != null) OnDeath();
        }
	}
   public void Damage(float dmg)
    {
        health.plainValue -= dmg;
    }
}
