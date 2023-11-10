using UnityEngine;

[CreateAssetMenu(fileName ="Item",menuName ="Inventory/Items/New Item")]
public class ItemCreater : ItemScriptableObject
{
    public float healAmount;

    private void Start()
    {
        itemType = ItemType.Food;
    }
}