using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DamageEnamy : MonoBehaviour
{
    public AudioClip myClip;
    private AudioSource mySourse;

    void Start()
    {
        mySourse = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider myCollider)
    {
        if (myCollider.tag == ("Player"))
        {
            myCollider.GetComponent<PlayerLevelHealth>().HealthChanger(-10);
            mySourse.PlayOneShot(myClip);
        }
    }
}