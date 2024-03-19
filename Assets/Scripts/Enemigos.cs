using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;

public class Enemigos : MonoBehaviour
{

    public float damage;
    private float nextAttackTime = 0f;
    private float timeBetweenAttacks = 1.5f;
    private float attackRange = 3f;
    private NavMeshAgent pathfinder;
    private Transform target;
    private GameObject player;
    private Camera playerCam;
    private bool bfinPartida;

    float vidaRestante;
    public Image imgBarraVida;
    public Canvas barraVida;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        pathfinder = GetComponent<NavMeshAgent>();
        pathfinder.SetDestination(target.position);
        playerCam = Camera.main;
        bfinPartida = false;

        Player.onDeadPlayer += finPartida;
    }

    // Update is called once per frame
    void Update()
    {
        if(!bfinPartida){
            pathfinder.SetDestination(target.position);
            barraVida.transform.LookAt(playerCam.transform.position, Vector3.up);
        
            if (Time.time >= nextAttackTime){
                nextAttackTime = Time.time + timeBetweenAttacks;
                float distanceToPlayer = Vector3.Distance(transform.position, target.position);
                if(distanceToPlayer <= attackRange){
                    player.SendMessage("tocado", damage, SendMessageOptions.DontRequireReceiver);
                    Debug.Log("Daño recibido: " + damage + " Vida restatnte: " + player.GetComponent<gestionVidas>().vida);
                }
            } 
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
