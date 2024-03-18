using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigos : MonoBehaviour
{
    public float movementInterval = 0.16f;
    private NavMeshAgent pathfinder;
    private Transform target;
    private float movementTimer;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        pathfinder = GetComponent<NavMeshAgent>();
        movementTimer = movementInterval;
        pathfinder.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        movementTimer -= Time.deltaTime;
        if(movementTimer < 0){
            pathfinder.SetDestination(target.position);
            movementTimer = movementInterval;
        }

    }
}
