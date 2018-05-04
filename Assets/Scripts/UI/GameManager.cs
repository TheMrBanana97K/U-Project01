using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
    Player player;
    public GameObject GameOver;
    public GameObject Instructions;
    public Text HP;
    bool isGameOver;
    // Use this for initialization
    void Start () {
      player=  FindObjectOfType<Player>();
        player.OnDeath += OnGameOver;


    }
	
	// Update is called once per frame
	void Update () {
        HP.text = player.health.getValue().ToString();
        if (isGameOver)
        {

        }
	}
    void OnGameOver()
    {
        isGameOver = true;
        GameOver.SetActive(true);
        Instructions.SetActive(false);
    }
}
