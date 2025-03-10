using UnityEngine;
using TMPro;

[DefaultExecutionOrder (3)]
public class EnemyRed : Enemy
{
    [SerializeField] Animator animator;
    void Awake()
    {
        GetTMP();
        level = 1;
        strength = 0;
        speed = 1;
        swagger = 0;
        intelligence = 0;
        animator = gameObject.GetComponent<Animator>();
    }

     public override void StartFightAnimation()
    {
        animator.SetTrigger("Fight");
    }
    void Update()
    {
        CheckIfDead();
    }
}
