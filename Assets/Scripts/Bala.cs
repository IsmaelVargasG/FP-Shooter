using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 50f;
    public float daño = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movDistancia = Time.deltaTime * velocidad;
        transform.Translate(Vector3.up * movDistancia);

        if(gameObject != null){
            Destroy(gameObject, 3f);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Enemigo")){
            other.SendMessage("tocado", daño, SendMessageOptions.DontRequireReceiver);
        }
        Destroy(gameObject);
    }
}
