using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerTest : MonoBehaviour {
    Player player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.Damage(10f);
        }
	}
}
