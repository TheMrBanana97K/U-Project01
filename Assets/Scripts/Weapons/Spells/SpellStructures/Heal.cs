using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spell/HealSpell")]
public class HealSpell : Ability
{

    GameObject parent;
    public float HealAmout;
     Player target;
    


    public override void Initialize(GameObject obj)
    {
        parent = obj;
        target = GameObject.FindObjectOfType<Player> ();
    }

    public override void TriggerAbility()
    {
        target.health.plainValue += HealAmout;
        
    }


}
