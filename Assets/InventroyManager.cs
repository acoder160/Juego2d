using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventroyManager : MonoBehaviour
{
    public GameObject inventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;
    

    // Start is called before the first frame update
    void Start()
    {
        inventoryMenu.SetActive(false);
        menuActivated = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && menuActivated) {
            Time.timeScale = 1f; // Pause the game
            inventoryMenu.SetActive(false);
            menuActivated = false;
           

        }
        else if (Input.GetKeyDown(KeyCode.E) && !menuActivated)
        {
            Time.timeScale = 0f; // Pause the game
            inventoryMenu.SetActive(true);
            menuActivated = true;

        }
    }
    public void AddItem(string itemName, int quantity, Sprite sprite, String itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false) {
                itemSlot[i].addItem(itemName, quantity, sprite, itemDescription);
                return;
            }
        }
    }
    public void DeselectAllSlots() {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].itemHasBeenSelected = false;
        }
    }
}
