
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public bool isGrounded;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;      
    }
}




