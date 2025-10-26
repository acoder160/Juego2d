using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{

    // Item Data
    public string itemName;
    public int quantity;
    public Sprite sprite;
    public bool isFull;
    public string itemDescription;


    // Item Slot
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;
    [SerializeField] PlayerHealth playerHealth;

    // descriptionPanel

    public Image descriptionImage;
    public TMP_Text descriptionItemNameText;
    public TMP_Text descriptionItemText;

    public GameObject selectedShader;
    public bool itemHasBeenSelected;

    private InventroyManager inventroyManager;

    // Start is called before the first frame update

    void Start()
    {
        inventroyManager = GameObject.Find("InventoryCanvas").GetComponent<InventroyManager>();
        isFull = false;
        itemHasBeenSelected = false;
    }
    public void addItem(string itemName, int quantity, Sprite sprite, string itemDescription)
    { 
        this.itemName = itemName;
        this.quantity = quantity;
        this.sprite = sprite;
        this.itemDescription = itemDescription;
        isFull = true;
        itemImage.sprite = sprite;
 
        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }
    void OnLeftClick()
    {
        inventroyManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        itemHasBeenSelected = true;
        descriptionItemNameText.text = itemName;
        descriptionItemText.text = itemDescription;
        descriptionImage.sprite = sprite;
    }
    void OnRightClick()
    {
        if (itemName == "Health Potion")
        {
            UseHealthPotion();
        }
    }

    void UseHealthPotion()
    {
        if (playerHealth != null)
        {
            // Restore 1 HP (you can change this amount)
            playerHealth.heal();

           
            ClearSlot();
           
        }
    }
    void ClearSlot()
    {
        itemName = "";
        sprite = null;
        itemDescription = "";
        isFull = false;
        itemImage.sprite = null;
        quantityText.text = "";
        itemImage.enabled = false;
        itemHasBeenSelected = false;
    }


}
