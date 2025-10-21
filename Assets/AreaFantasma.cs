using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaFantasma : MonoBehaviour
{
    public float radioBusqueda = 5f;
    public LayerMask capaJugador;
    public float velocidadMovimiento = 3f;
    public float distanciaMaxima = 8f;

    private Transform transformJugador;
    private Vector3 puntoInicial;
    private EstadosMovimiento estadoActual;

    public enum EstadosMovimiento
    {
        Esperando,
        Siguiendo,
        Volviendo
    }

    void Start()
    {
        puntoInicial = transform.position;
        estadoActual = EstadosMovimiento.Esperando;
    }

    void Update()
    {
        switch (estadoActual)
        {
            case EstadosMovimiento.Esperando:
                EstadoEsperando();
                break;

            case EstadosMovimiento.Siguiendo:
                EstadoSiguiendo();
                break;

            case EstadosMovimiento.Volviendo:
                EstadoVolviendo();
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

    private void EstadoSiguiendo()
    {
        if (transformJugador == null)
        {
            estadoActual = EstadosMovimiento.Volviendo;
            return;
        }

        // Mover hacia el jugador
        transform.position = Vector2.MoveTowards(transform.position, transformJugador.position, velocidadMovimiento * Time.deltaTime);

        // Si el jugador se aleja demasiado, volver
        float distancia = Vector2.Distance(transform.position, transformJugador.position);
        if (distancia > distanciaMaxima)
        {
            estadoActual = EstadosMovimiento.Volviendo;
        }
    }

    private void EstadoVolviendo()
    {
        // Mover de vuelta al punto inicial
        transform.position = Vector2.MoveTowards(transform.position, puntoInicial, velocidadMovimiento * Time.deltaTime);

        // Cuando llega al punto inicial, esperar de nuevo
        if (Vector2.Distance(transform.position, puntoInicial) < 0.1f)
        {
            transformJugador = null;
            estadoActual = EstadosMovimiento.Esperando;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioBusqueda);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(puntoInicial, 0.2f);
    }
}
