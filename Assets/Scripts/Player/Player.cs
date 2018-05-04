using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("Player Stats")]
    public Statistic health=new Statistic(0f,100f,1000f);
    public Statistic energy=new Statistic(0f,100f,1000f);

    public System.Action OnDeath;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (health.getValue() < 0)
        {
            if (OnDeath != null) OnDeath();
        }
	}

}
