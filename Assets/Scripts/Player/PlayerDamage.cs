using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public AudioClip myClip;
    private AudioSource mySourse;

    void Start()
    {
        mySourse = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider myCollider)
    {
        if (myCollider.tag == ("Enemy"))
        {
            myCollider.GetComponent<EnemyLevelHealth>().HealthChangerEnemy(-100);
            mySourse.PlayOneShot(myClip);
        }
    }
}
