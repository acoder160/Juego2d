using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bala : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float tiempoVida;
    private SpriteRenderer spriteRenderer;
    public bool side;

    // Start is called before the first frame update



    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Destroy(gameObject, tiempoVida);
    }
    void Update()
    {
        if (side == true)
        {
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);
            spriteRenderer.flipX = true;

        }
        else if (side == false)
        {
            transform.Translate(Vector2.right * velocidad * Time.deltaTime);
            spriteRenderer.flipX = false;
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            Destroy(other.gameObject);
            GameObject.Destroy(gameObject);
        }
    }

}

