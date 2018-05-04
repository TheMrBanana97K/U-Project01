using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Statistic healthStat;


	// Use this for initialization
	void Start () {
        StartCoroutine(DecreaseHealth());
	}
	
	// Update is called once per frame
	void Update () {

	}
    IEnumerator DecreaseHealth()
    {
        while (healthStat.getValue()>0)
        {
            healthStat.plainValue -= 1;
            yield return new WaitForSeconds(1);
        }
        print("Dead");
    }
}
