using StarterAssets;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("�ǤH")]
    public Enemy enemy;
    [Header("�ǤH�ʵe")]
    public Animator aniEnemy;

    [Header("�p�°ʵe")]
    public Animator aniPlayer;
    [Header("�p�¨��ⱱ�")]
    public CharacterController characterPlayer;
    [Header("�p�¨��ⱱ�")]
    public ThirdPersonController controllerPlayer;


    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("�L���ϰ�")) Pass();
        if (other.name.Contains("�ǤH�����ϰ�")) Lose();
    }

    private void Pass()
    {
        aniEnemy.SetBool("��������", false);
        enemy.enabled = false;
    }

    private void Lose()
    {
        aniPlayer.enabled = false;
        characterPlayer.enabled = false;
        controllerPlayer.enabled = false;
    }
}
