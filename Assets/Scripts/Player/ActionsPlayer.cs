using System.Collections;
using StarterAssets;
using UnityEngine;

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
            if (quickslotInventory.activeSlot != null)
            {
                if (quickslotInventory.activeSlot.item != null)
                {
                    if (quickslotInventory.activeSlot.item.itemType == ItemType.Weapon)
                    {
                        if (inventoryManager.isOpened == false)
                        {
                            anim.SetBool("AtackSword", true);
                            canAttack = false;
                            StartCoroutine(EnableAttackAfterDelay(1.3f));
                            _thirdPersonController.Update();
                        }
                    }
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            anim.SetBool("AtackSword", false);
        }
    }

    IEnumerator EnableAttackAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canAttack = true;
    }
}