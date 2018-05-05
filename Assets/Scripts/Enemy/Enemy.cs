using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour {

   public  enum EnemyState{Chasing,Idle,Attacking };
    public EnemyState state;

    public int speed;
    public int attackSpeed;
    public int attackDamage = 10;
    
    public int timeBetweenAttacks=300; // in ms
    public float attackDistance;

    Material skinMaterial;
    NavMeshAgent pathfinder;
    Transform target;
    Player targetPlayer;
    bool hasTarget;
    System.Diagnostics.Stopwatch attackTime = new System.Diagnostics.Stopwatch();

	// Use this for initialization
	void Start () {
        skinMaterial = GetComponent<Renderer>().material;
        pathfinder = GetComponent<NavMeshAgent>();
        pathfinder.speed = speed;
        attackTime.Start();
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            state = EnemyState.Chasing;
            hasTarget = true;

            target = GameObject.FindGameObjectWithTag("Player").transform;
            targetPlayer = target.GetComponent<Player>();
            targetPlayer.OnDeath += OnTargetDeath;

            StartCoroutine(ChasePlayer());


        }
	}
	
	// Update is called once per frame
	void Update () {
        if (hasTarget)
        {
            
            if (attackTime.ElapsedMilliseconds > timeBetweenAttacks)
            {
                attackTime.Stop();
                float sqrDstToTarget = (target.position - transform.position).sqrMagnitude;
                if (sqrDstToTarget < Mathf.Pow(attackDistance, 2))
                {

                    attackTime.Reset();
                    attackTime.Start();
                    StartCoroutine(Attack());
                }
            }
            
        }
    }
    void OnTargetDeath()
    {
        hasTarget = false;
        state = EnemyState.Idle;
    }

    IEnumerator ChasePlayer()
    {
        while (target != null)
        {
            if (state == EnemyState.Chasing)
            {
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                Vector3 targetPosition = target.position - dirToTarget;
                pathfinder.SetDestination(targetPosition);
            }

          
    

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
        targetPlayer.Damage(attackDamage);
        state = EnemyState.Chasing;
        pathfinder.enabled = true;
    }
}
