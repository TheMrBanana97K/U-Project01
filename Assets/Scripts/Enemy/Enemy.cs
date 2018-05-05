using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour {

   public  enum EnemyState{Chasing,idle,Attacking };
    public EnemyState state;

    public int speed;
    public int attackSpeed;

    Material skinMaterial;
    NavMeshAgent pathfinder;
    Transform target;
	// Use this for initialization
	void Start () {
        skinMaterial = GetComponent<Renderer>().material;
        pathfinder = GetComponent<NavMeshAgent>();
        pathfinder.speed = speed;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        state = EnemyState.Chasing;
        StartCoroutine(ChasePlayer());
	}
	
	// Update is called once per frame
	void Update () {
    }

    IEnumerator ChasePlayer()
    {
        while (target != null)
        {
            if (state == EnemyState.Chasing)
            {
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                Vector3 targetPosition = target.position - dirToTarget * 5;
                pathfinder.SetDestination(targetPosition);
            }

            float distance = Vector3.Distance(transform.position, target.position);
            float distancePercent = (distance * 10 - 10) / 100;
    

            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator Attack()
    {
        state = EnemyState.Attacking;
        pathfinder.enabled = false;

        Vector3 orginalPosition = transform.position;
        Vector3 attackPosition = target.position;
        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;
            float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector3.Lerp(orginalPosition, attackPosition, interpolation);
            yield return null;
        }
    }
}
