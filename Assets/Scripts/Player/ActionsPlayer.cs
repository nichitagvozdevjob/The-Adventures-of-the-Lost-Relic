using StarterAssets;
using UnityEngine;
using System.Collections;

public class ActionsPlayer : MonoBehaviour
{
    public Animator anim;
    public InventoryManager inventoryManager;
    public QuickslotInventory quickslotInventory;

    private ThirdPersonController _thirdPersonController;
    private bool canAttack = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        _thirdPersonController = GetComponent<ThirdPersonController>();
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && anim.GetBool("Jump") == false && canAttack)
        {
            if (quickslotInventory.activeSlot != null && quickslotInventory.activeSlot.item != null &&
                quickslotInventory.activeSlot.item.itemType == ItemType.Weapon && !inventoryManager.isOpened)
            {
                StartCoroutine(PerformAttack());
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            anim.SetBool("AtackSword", false);
        }
    }

    IEnumerator PerformAttack()
    {
        anim.SetBool("AtackSword", true);
        canAttack = false;
        yield return new WaitForSeconds(1.16f); // Устанавливаем время атаки в 1.16 секунды
        anim.SetBool("AtackSword", false);
        yield return new WaitForSeconds(0.14f); // Оставшиеся 0.14 секунды
        canAttack = true;
    }
}