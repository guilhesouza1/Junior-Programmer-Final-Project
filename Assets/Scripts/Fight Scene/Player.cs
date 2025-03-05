using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[DefaultExecutionOrder(2)]
public class Player : Fighter
{
    public int maxXp;
    public int currentXp;
    public bool isDead;
    public int intelligenceCost = 5;
    public int speedCost = 4;
    public int strengthCost = 4;
    public int swaggerCost = 5;
    public TextMeshProUGUI damageUI;
   
    void Awake()
    {
        level = 1;
        strength = 1;
        speed = 2;
        swagger = 1;
        intelligence = 1;
        maxXp = 0;

        currentXp = maxXp;
    }
    public override IEnumerator Fight()
    {
        animator.SetTrigger("PlayerFight");
        Enemy firstEnemy = FindFirstObjectByType<Enemy>();
        int diceRollEnemy = Random.Range(1, 7);
        int diceRollPlayer = Random.Range(1, 7);
        int enemySpeed = firstEnemy.speed + diceRollEnemy;
        int playerSpeed = speed + diceRollPlayer;

        if (diceRollEnemy == 1 && diceRollPlayer == 6)
        {
            criticalHit = true;
            int damageTaken = (strength + Random.Range(1, 7)) * 2;
            firstEnemy.TakeDamage(damageTaken);
            Debug.Log("Critical Hit! You've dealt " + damageTaken + "HP damage!");
        }
        else if (diceRollEnemy == 6 && diceRollPlayer == 1)
        {
            criticalFailure = true;
            int damageTaken = strength + Random.Range(1, 7);
            TakeDamage(damageTaken);
            Debug.Log("Critical Failure! You've suffered " + damageTaken + "HP damage!");
        }
        else if (!criticalFailure && !criticalHit && enemySpeed >= playerSpeed)
        {
            Debug.Log("Miss");
        }
        else if (!criticalFailure && !criticalHit && enemySpeed < playerSpeed)
        {
            int damageTaken = strength + Random.Range(1, 7);
            firstEnemy.TakeDamage(damageTaken);
            Debug.Log("Hit! You've dealt " + damageTaken + "HP damage");
        }
        return base.Fight();
    }
    void Update()
    {
        LevelUp();
        CheckIfDead();
        maxHp = (strength + speed) * 2;
        maxMp = intelligence + swagger;
    }
    void CheckIfDead()
    {
        if (currentHp <= 0)
        {
            isDead = true;
            Destroy(gameObject);
        }
    }
    public void LevelUp()
    {
        if (maxXp ==  5 * (1 + level) * level)
        {
            level++;
            currentHp = maxHp;
            Debug.Log("Level up! You are now level " + level + "!");
        }
        else
            return;
    }
}
