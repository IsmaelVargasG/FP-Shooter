using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class gestionVidas : MonoBehaviour
{
    public float vida = 5f;
    public float maxVida = 5f;

    public UnityEvent heSidoTocado;
    public UnityEvent muelto;

    public delegate void OnDeadEnemy();
    public static event OnDeadEnemy onDeadEnemy;

    void tocado(float daño){
        vida -= daño;
        heSidoTocado.Invoke();
        if(vida <= 0){
            muelto.Invoke();
            if(onDeadEnemy != null){
                onDeadEnemy();
            }
        }
    }
}
