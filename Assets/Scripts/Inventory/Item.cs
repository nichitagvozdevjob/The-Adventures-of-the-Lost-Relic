using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Item : MonoBehaviour
{
    [FormerlySerializedAs("itemScriptableObject")] public ItemScriptableObject item;
    public int amount;
}
