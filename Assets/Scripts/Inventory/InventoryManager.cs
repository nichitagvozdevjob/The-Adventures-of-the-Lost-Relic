using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject UIBG;
    public GameObject crosshair;
    public Transform inventoryPanel;
    public Transform quickslotPanet;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public bool isOpened;
    public float reachDistance = 55;
    
    public Transform mTransform;


    void Awake()
    {
        UIBG.SetActive(true);
    }

    void Start()
    {

        UIBG.SetActive(false);
        AddSlot();
        inventoryPanel.gameObject.SetActive(false);
    }

    void Update()
    {
        isOpenedInventory();
        Ray(); 
    }

    void AddSlot()
    {
        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            if (inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        
        for (int i = 0; i < quickslotPanet.childCount; i++)
        {
            if (quickslotPanet.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(quickslotPanet.GetChild(i).GetComponent<InventorySlot>());
            }
        }
    }
    
    void isOpenedInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpened = !isOpened;
            if (isOpened)
            {
                UIBG.SetActive(true);
                inventoryPanel.gameObject.SetActive(true);
                crosshair.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                UIBG.SetActive(false);
                inventoryPanel.gameObject.SetActive(false);
                crosshair.SetActive(true); 
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    void Ray()
    {
        Ray ray = new Ray(mTransform.position, mTransform.forward);
        RaycastHit hit;
        
        if(Input.GetKeyDown(KeyCode.E))
        {    
            if (Physics.Raycast(ray, out hit, reachDistance))
            {
                if (hit.collider.gameObject.GetComponent<Item>() != null)
                {
                    
                    AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>().amount);
                    
                    Destroy(hit.collider.gameObject);
                }
                Debug.DrawRay(ray.origin, ray.direction*reachDistance, Color.green);
            }
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * reachDistance, Color.red);
        }
    }

    void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == _item)
            {
                if (slot.amount + _amount <= _item.maximumAmount)
                {
                    slot.amount += _amount;
                    slot.itemAmountText.text = slot.amount.ToString();
                    return;
                }
                break;
            }
        }

        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty == true)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                if (slot.item.maximumAmount != 1)
                {
                    slot.itemAmountText.text = _amount.ToString();
                }
                break;
            }
        }
    }
}
