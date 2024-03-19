using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ametralladora : MonoBehaviour
{
    Transform salida;
    AudioSource audioSource;
    Animation animacion;
    public GameObject bala;

    float proximoDisparo = 0f;
    float tiempoDeEspera = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animacion = GetComponent<Animation>();
        salida = gameObject.transform.GetChild(0).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= proximoDisparo && Input.GetMouseButton(0)){
            proximoDisparo = Time.time + tiempoDeEspera;

            audioSource.Play();
            animacion.wrapMode = WrapMode.Once;
            animacion.Play();

            GameObject nuevaBala = Instantiate(bala, salida.position, salida.rotation);
        }
    }
}
