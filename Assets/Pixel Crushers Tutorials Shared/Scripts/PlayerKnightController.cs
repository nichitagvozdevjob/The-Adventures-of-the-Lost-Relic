using UnityEngine;
using UnityEngine.AI;

// LMB moves to where the player clicks.
// RMB attacks.
public class PlayerKnightController : MonoBehaviour
{

    public float attackHitDelay = 0.5f;

    protected NavMeshAgent m_navMeshAgent;
    protected Animator m_animator;
    protected Vector3 m_destination;

    protected virtual void Awake()
    {
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        m_animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        if (UnityEngine.EventSystems.EventSystem.current != null && UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) return;
        if (Input.GetMouseButton(0))
        {
            var playerPlane = new Plane(Vector3.up, transform.position);
            var ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            var hitdist = 0.0f;
            if (playerPlane.Raycast(ray, out hitdist))
            {
                m_destination = ray.GetPoint(hitdist);
                m_navMeshAgent.SetDestination(m_destination);
                m_navMeshAgent.isStopped = false;
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            m_animator.SetTrigger("Attack");
            Invoke("CheckAttack", attackHitDelay);
        }
        else if (Vector3.Distance(transform.position, m_destination) < 1)
        {
            m_navMeshAgent.isStopped = true;
        }
    }

    protected virtual void CheckAttack()
    {
        foreach (var hit in Physics.OverlapSphere(transform.position + transform.forward, 1))
        {
            Attack(hit.GetComponent<Attackable>());
        }
    }

    protected virtual void Attack(Attackable attackable)
    {
        if (attackable != null) attackable.GetHit();
    }

}
