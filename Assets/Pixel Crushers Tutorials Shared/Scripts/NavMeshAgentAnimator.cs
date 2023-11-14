using UnityEngine;
using UnityEngine.AI;

// Matches a character's animator Speed parameter with its NavMeshAgent's speed.
public class NavMeshAgentAnimator : MonoBehaviour
{

    private NavMeshAgent m_navMeshAgent;
    private Animator m_animator;

    private void Awake()
    {
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        m_animator = GetComponent<Animator>();
    }

    private void Update()
    {
        m_animator.SetFloat("Speed", m_navMeshAgent.velocity.magnitude);
    }

}
