using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Player : MonoBehaviour
{
    float vidaRestante;
    public Image imgBarraVida;
    public Canvas barraVida;
    private float x;

    public delegate void OnDeadPlayer();
    public static event OnDeadPlayer onDeadPlayer;

    void Start(){
        x = imgBarraVida.transform.localScale.x;
    }

    public void heSidoTocado(){
        vidaRestante = GetComponent<gestionVidas>().vida / GetComponent<gestionVidas>().maxVida;
        float y = imgBarraVida.transform.localScale.y;
        float z = imgBarraVida.transform.localScale.z;
        imgBarraVida.transform.localScale = new Vector3(vidaRestante*x, y, z);
    }

    public void muelto(){
        if(onDeadPlayer != null){
            onDeadPlayer();
        }
        Destroy(gameObject);
        EditorApplication.isPlaying = false;
    }
}
