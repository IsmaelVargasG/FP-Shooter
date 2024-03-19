using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;

public class Enemigos : MonoBehaviour
{

    public float movementInterval = 0.16f;
    private NavMeshAgent pathfinder;
    private Transform target;
    private float movementTimer;
    private Camera playerCam;
    private bool bfinPartida;

    float vidaRestante;
    public Image imgBarraVida;
    public Canvas barraVida;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        pathfinder = GetComponent<NavMeshAgent>();
        movementTimer = movementInterval;
        pathfinder.SetDestination(target.position);
        playerCam = Camera.main;
        bfinPartida = false;

        Player.onDeadPlayer += finPartida;
    }

    // Update is called once per frame
    void Update()
    {
        if(!bfinPartida){
            movementTimer -= Time.deltaTime;
            if(movementTimer < 0){
                pathfinder.SetDestination(target.position);
                movementTimer = movementInterval;
            }


            pathfinder.SetDestination(target.position);
            barraVida.transform.LookAt(playerCam.transform.position, Vector3.up);
        }
    }

    public void heSidoTocado(){
        vidaRestante = GetComponent<gestionVidas>().vida / GetComponent<gestionVidas>().maxVida;
        imgBarraVida.transform.localScale = new Vector3(vidaRestante, 1, 1);
    }

    public void muelto(){
        Destroy(gameObject);
    }

    void finPartida(){
        bfinPartida = true;
    }
}
