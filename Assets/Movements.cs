using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] float runSpeed = 15;
    [SerializeField] float jumpSpeed = 17;
    [SerializeField] int damageTaken = 1;
    [SerializeField] DisparoJugador disparo;
    public CheckGround checkGround;
    public CheckParedLeft checkParedLeft;
    public CheckParedRight checkParedRight;
    public SpriteRenderer spriteRender;
    public Animator animator;
    public PlayerHealth health;
    [SerializeField] public UnityEngine.UI.Image skillCooldown;
    // cooldown
    private float cooldown = 1f;
    private float lastActionTime = 0f;
    private int counter = 0;
    public bool skillReady = true;


    // Start is called before the first frame update


    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (!skillReady && counter < 2001)
        {

            skillCooldown.fillAmount -= 0.0005f;
            counter++;
        }
        else {
            skillReady = true;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        animator.SetFloat("Speed", Mathf.Abs(body.velocity.x)); // Mathf.Abs is absolute value it means Mathf.Abd(-1) = (1)

        if (Input.GetKey(KeyCode.Q) && (skillReady))
        {
            animator.SetTrigger("atack");
            counter = 0;
            skillCooldown.fillAmount = 1f;
            skillReady = false;
            disparo.disparo();
        }
            if (checkParedLeft.checkEnemigo && (Time.time > lastActionTime + cooldown))
            {

                body.velocity = new Vector2(body.velocity.x, (jumpSpeed / 2));
                animator.SetTrigger("damageRecieved");
                health.takeDamage(damageTaken);
                lastActionTime = Time.time;


            }
            else if (checkParedRight.checkEnemigo && (Time.time > lastActionTime + cooldown))
            {

                body.velocity = new Vector2(body.velocity.x, (jumpSpeed / 2));
                animator.SetTrigger("damageRecieved");
                health.takeDamage(damageTaken);
                lastActionTime = Time.time;
            }
            else
            {
                if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && checkGround.isGrounded)
                {
                    // vector2. 1st argument axe x. In this case it follows as it was. 2nd argument. applies our new force 
                    body.velocity = new Vector2(body.velocity.x, jumpSpeed);

                // en el proyecto existen 3 distintas animaciones del salto asi que he decidido eligir una animacion aleatoriamente.
                int jumpAnim = UnityEngine.Random.Range(1, 4);

                animator.SetTrigger("jump" + jumpAnim);
                }
                if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && (checkParedLeft.checkPared == false))
                {
                    body.velocity = new Vector2(runSpeed, body.velocity.y);
                    spriteRender.flipX = false;
                }
                else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (checkParedRight.checkPared == false))
                {
                    body.velocity = new Vector2(-1f * runSpeed, body.velocity.y);
                    spriteRender.flipX = true;
                }
                else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    body.velocity = new Vector2(body.velocity.x, -1f * jumpSpeed);
                }
                else
                {
                    body.velocity = new Vector2(0, body.velocity.y);
                }
            }


        }
    }

