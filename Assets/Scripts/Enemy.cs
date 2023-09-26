using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField,Header("移動速度"), Range(0, 10)]
    private float speed = 3f;

    private NavMeshAgent agent;

    private Transform target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.speed = speed;

        target = GameObject.Find("小黑").transform;
    }

    private void Update()
    {
        agent.SetDestination(target.position);
    }
}
