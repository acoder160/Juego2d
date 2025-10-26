
using UnityEngine;

public class CheckParedLeft : MonoBehaviour
{
    public bool checkPared;
    public bool checkEnemigo;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            checkPared = true;
        }
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            checkEnemigo = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            checkPared = false;
        }
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            checkEnemigo = false;
        }
    }
}
