using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigos : MonoBehaviour
{
    NavMeshAgent pathfinder;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        pathfinder = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        pathfinder.SetDestination(target.position);
    }
}
