using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventory;
    public Transform inventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public bool isOpened;
    public float reachDistance = 45;

    //public Camera mainCamera;
    public Transform mTransform;

    private void Start()
    {
        //mainCamera = Camera.main;
        inventory.SetActive(false);
        AddSlot();
        
    }

    private void Update()
    {
        isOpenedInventory();
    }

    private void AddSlot()
    {
        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            if (inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
    }
    
    private void isOpenedInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpened = !isOpened;
            if (isOpened)
            {
                inventory.SetActive(true);
            }
            else
            {
                inventory.SetActive(false);
            }
        }
    }

    void FixedUpdate()
    {
        Ray ray = new Ray(mTransform.position, mTransform.forward);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, reachDistance))
        {
            if(Input.GetKeyDown(KeyCode.E))
            Debug.DrawRay(ray.origin, ray.direction * reachDistance, Color.green);
            if (hit.collider.gameObject.GetComponent<Item>() != null)
            {
                AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>(). amount);
                Destroy(hit.collider.gameObject);
            }
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * reachDistance, Color.blue);
        }
    }

    private void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == _item)
            {
                slot.amount += _amount;
                return;
            }
        }

        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty == false)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
            }
        }
    }
}
