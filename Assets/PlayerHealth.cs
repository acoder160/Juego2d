using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 4;
    [SerializeField] public int health;
    [SerializeField] public UnityEngine.UI.Image totalHealthBar;

    [SerializeField] public UnityEngine.UI.Image currentHealthBar;
    public GameOver youDied;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;   
    }


    public void takeDamage(int damage)
    {
        health -= damage;

        switch (health) {
            case 4:
                currentHealthBar.fillAmount = 1f;  // 100% health
                break;
            case 3:
                currentHealthBar.fillAmount = 0.75f;  
                break;
            case 2:
                currentHealthBar.fillAmount = 0.5f;  
                break;
            case 1:
                currentHealthBar.fillAmount = 0.25f;  
                break;
            case 0:
                currentHealthBar.fillAmount = 0f;
                break;
        }

        if (health < 0)
        {
            youDied.gameOver();
            Destroy(gameObject);
        }
       
    }
    public void heal()
    {
        health = maxHealth;
        currentHealthBar.fillAmount = 1f;  // 100% health
    }

    }
