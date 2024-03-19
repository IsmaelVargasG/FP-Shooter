using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    float vidaRestante;
    public Image imgBarraVida;
    public Canvas barraVida;

    public delegate void OnDeadPlayer();
    public static event OnDeadPlayer onDeadPlayer;

    public void heSidoTocado(){
        vidaRestante = GetComponent<gestionVidas>().vida / GetComponent<gestionVidas>().maxVida;
        imgBarraVida.transform.localScale = new Vector3(vidaRestante, 1, 1);
    }

    public void muelto(){
        if(onDeadPlayer != null){
            onDeadPlayer();
        }
        Destroy(gameObject);
    }
}
