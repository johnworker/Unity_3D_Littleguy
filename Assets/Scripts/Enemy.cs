using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField,Header("移動速度"), Range(0, 10)]
    private float speed = 3f;

    [SerializeField, Header("攻擊冷卻時間"), Range(0, 10)]
    private float attackCD = 4.5f;

    [SerializeField, Header("攻擊區域")]
    private GameObject goAttackAera;

    [SerializeField, Header("啟動攻擊區域時間"), Range(0, 5)]
    private float showAttackAeraTime = 1.5f;

    [SerializeField, Header("啟動攻擊區域持續時間"), Range(0, 5)]
    private float showAttackAeraDurationTime = 0.5f;

    private NavMeshAgent agent;

    private Transform target;

    private Animator ani;

    private string parWalk = "走路開關";
    private string parAttack = "觸發攻擊";

    private bool canAttack = true;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.speed = speed;

        target = GameObject.Find("小黑").transform;

        ani = GetComponent<Animator>();

        StartCoroutine(Test());
    }

    private void Update()
    {
        agent.SetDestination(target.position);

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            ani.SetBool(parWalk, true);
        }
        else if(agent.remainingDistance != 0)
        {
            if (canAttack) StartCoroutine(AttackEffect());
        }
    }

    private IEnumerator AttackEffect() 
    {
        canAttack = false;
        agent.isStopped = true;

        Vector3 look = target.position;
        look.y = transform.position.y;
        transform.LookAt(look);

        ani.SetTrigger(parAttack);
        yield return new WaitForSeconds(showAttackAeraTime);
        goAttackAera.SetActive(true);
        yield return new WaitForSeconds(showAttackAeraDurationTime);
        goAttackAera.SetActive(false);
        ani.SetBool(parWalk, false);
        yield return new WaitForSeconds(attackCD);
        canAttack = true;
        agent.isStopped = false;
    }

    private IEnumerator Test() 
    {
        print("第一");
        yield return new WaitForSeconds(1);
        print("第二");
        yield return new WaitForSeconds(2);
        print("第三");
    }
}
