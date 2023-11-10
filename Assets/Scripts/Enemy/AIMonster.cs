using UnityEngine;
using UnityEngine.AI;

public class AIMonster : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _agent;
    private GameObject _player;
    private float _speed;
    private bool _MoveToPlayer;

    public Transform[] wayPoints;
    public int Current_Patch;
    public enum AI_State { Patrol, Stay };
    public AI_State AI_Enemy;

    void Start()
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();
        _speed = _agent.speed;
        _player = GameObject.FindGameObjectWithTag("Player");
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveToPlayer();
    }

    void MoveToPlayer()
    {
        float Dist_Player = Vector3.Distance(_player.transform.position, gameObject.transform.position);

        // Run
        if (Dist_Player < 50)
        {
            _anim.SetBool("Run", true);
            _anim.SetBool("Attack", false);

            _agent.SetDestination(_player.transform.position);
        }
        else
        {
            if (AI_Enemy == AI_State.Patrol)
            {
                _agent.Resume();
                gameObject.GetComponent<Animator>().SetBool("Run", true);
                _agent.SetDestination(wayPoints[Current_Patch].transform.position);
                float Patch_Dist = Vector3.Distance(wayPoints[Current_Patch].transform.position, gameObject.transform.position);
                if (Patch_Dist < 10)
                {
                    Current_Patch++;
                    Current_Patch = Current_Patch % wayPoints.Length;
                }

                if (AI_Enemy == AI_State.Stay)
                {
                    gameObject.GetComponent<Animator>().SetBool("Run", false);
                    _agent.Stop();
                }
            }
        }

        // Attack
        if (Dist_Player < 10)
        {
            _anim.SetBool("Attack", true);

            _agent.Stop();
        }
        else
        {
            _anim.SetBool("Attack", false);

            if (_agent.isStopped)
            {
                _agent.Resume();
            }
        }
    }

    void MoveToPoint()
    {
        // if (AI_Enemy == AI_State.Patrol)
        // {
        //     _agent.Resume();
        //     gameObject.GetComponent<Animator>().SetBool("Run", true);
        //     _agent.SetDestination(wayPoints[Current_Patch].transform.position);
        //     float Patch_Dist = Vector3.Distance(wayPoints[Current_Patch].transform.position, gameObject.transform.position);
        //     if (Patch_Dist < 10)
        //     {
        //         Current_Patch++;
        //         Current_Patch = Current_Patch % wayPoints.Length;
        //     }
        //
        //     if (AI_Enemy == AI_State.Stay)
        //     {
        //         gameObject.GetComponent<Animator>().SetBool("Run", false);
        //         _agent.Stop();
        //     }
        // }
    }
}
