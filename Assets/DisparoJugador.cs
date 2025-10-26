
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{

    [SerializeField] private Transform controladosDisparo;
    [SerializeField] private GameObject bala;
    [SerializeField] private NewBehaviourScript player;


    // Start is called before the first frame update
    void Update()
    {
        

    }

    public void disparo()
    {

        GameObject nuevaBala = Instantiate(bala, controladosDisparo.position, controladosDisparo.rotation);
        bala scriptBala = nuevaBala.GetComponent<bala>();
        scriptBala.side = player.spriteRender.flipX;

    }

}
