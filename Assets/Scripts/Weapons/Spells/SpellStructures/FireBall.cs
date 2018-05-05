using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Spell/FireBallSpell")]
public class FireBallAbility : Ability
{

    GameObject parent;
    public GameObject projectile;


    public override void Initialize(GameObject obj)
    {
        parent = obj;
    }

    public override void TriggerAbility()
    {
        GameObject obj =GameObject.Instantiate(projectile, parent.transform.position,Quaternion.identity);
        obj.transform.parent = null;
    }


}