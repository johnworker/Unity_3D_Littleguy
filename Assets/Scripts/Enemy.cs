using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField,Header("移動速度"), Range(0, 10)]
    private float speed = 3f;

    private NavMeshAgent agent;

    private Transform target;

    private Animator ani;

    private string parWalk = "走路開關";

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.speed = speed;

        target = GameObject.Find("小黑").transform;

        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        agent.SetDestination(target.position);
        ani.SetBool(parWalk, true);
    }
}
