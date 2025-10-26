using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class EnemigoMovimirnto : MonoBehaviour
{   
    public CheckGround checkGround;
    private Rigidbody2D body;
    public ScriptEnemigo stats;
    public SpriteRenderer spriteRender;
    public bool direccion;
    public EnemCheckParedes checkParedes;

    private float cooldown = 2f;
    private float lastActionTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        direccion = true; // por defecto enemigo va a ir a la parte izquierda
        body = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (checkGround.isGrounded) // si esta en el suelo realiza un salto
        {
            body.velocity = new Vector2(body.velocity.x, stats.jumpSpeed);
        }
        if (direccion) // direccion = true = ir a la izquierda
        {
            body.velocity = new Vector2(-1f * stats.runSpeed, body.velocity.y);
            spriteRender.flipX = true;
            if (transform.position.x < stats.xMin && checkGround.isGrounded) // El enemigo cambia de direcion cuando 1: esta en el suelo 2. se ha salido del rango
            {
                direccion = false;
            }
        }
        else if (!direccion) // a la derecha
        {
            body.velocity = new Vector2(stats.runSpeed, body.velocity.y);
            spriteRender.flipX = false;
            if (transform.position.x > stats.xMax && checkGround.isGrounded) 
            {
                direccion = true;
            }
        }
        if (checkParedes.checkPared && (Time.time > lastActionTime + cooldown))
        {
            direccion = !direccion;
            lastActionTime = Time.time;
        }
    }
}
