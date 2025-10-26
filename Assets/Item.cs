using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private int quantity;
    [SerializeField] private Sprite sprite;
    [SerializeField] private string itemDescription;
    [SerializeField] InventroyManager inventroyManager;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inventroyManager.AddItem(itemName, quantity, sprite, itemDescription);
            Destroy(gameObject);
        }
    }
}
