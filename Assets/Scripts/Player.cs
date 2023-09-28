using StarterAssets;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("怪人")]
    public Enemy enemy;
    [Header("怪人動畫")]
    public Animator aniEnemy;

    [Header("小黑動畫")]
    public Animator aniPlayer;
    [Header("小黑角色控制器")]
    public CharacterController characterPlayer;
    [Header("小黑角色控制器")]
    public ThirdPersonController controllerPlayer;


    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("過關區域")) Pass();
        if (other.name.Contains("怪人攻擊區域")) Lose();
    }

    private void Pass()
    {
        aniEnemy.SetBool("關閉走路", false);
        enemy.enabled = false;
    }

    private void Lose()
    {
        aniPlayer.enabled = false;
        characterPlayer.enabled = false;
        controllerPlayer.enabled = false;
    }
}
