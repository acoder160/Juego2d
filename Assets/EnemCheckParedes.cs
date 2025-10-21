using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemCheckParedes : MonoBehaviour
{
    // Start is called before the first frame update
    public bool checkPared;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            checkPared = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            checkPared = false;
        }
    }
}
