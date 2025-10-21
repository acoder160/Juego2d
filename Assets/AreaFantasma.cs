using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaFantasma : MonoBehaviour
{
    public float radioBusqueda;
    public LayerMask capaJugador;
    public Transform transformJugador;
    // Start is called before the first frame update
    public EstadosMovimiento estadoActual;
    public float VelocdadMovieminto;
    public float distanciaMaxima;
    public Vector3 puntoInicial;
    public enum EstadosMovimiento { 
    Esperando, Siguiendo, Volviendo
    }

    public void Start()
    {
        puntoInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (estadoActual)
        {
            case EstadosMovimiento.Esperando:
                EstadoEsperando();
                break;
            case EstadosMovimiento.Siguiendo:
                break;
            case EstadosMovimiento.Volviendo:
                break;
        }
    }

     private void EstadoEsperando()
    {
        Collider2D jugadorCollider = Physics2D.OverlapCircle(transform.position, radioBusqueda, capaJugador);
        if (jugadorCollider)
        {
            transformJugador = jugadorCollider.transform;
            estadoActual = EstadosMovimiento.Siguiendo;
        }

    }

    private void EstadoSiguiendo() {
        if (transformJugador == null) {
            estadoActual = EstadosMovimiento.Volviendo;
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position, transformJugador.position, VelocdadMovieminto * Time.deltaTime);
    }


    

        

       
        
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioBusqueda);
    }
}
