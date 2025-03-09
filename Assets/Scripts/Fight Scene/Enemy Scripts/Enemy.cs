using System.Collections;
using TMPro;
using UnityEngine;

public class Enemy : Fighter
{
    public bool isDead;
    public TextMeshProUGUI damageUI;

    public void GetTMP()
    {
        GameObject tmpGO = GameObject.Find("/UICanvas/DamageUI/DamageText");
        damageUI = tmpGO.GetComponent<TextMeshProUGUI>();
        //damageUI.text = " ";
    }
    public override void StartFightAction()
    {
        //animator.SetTrigger("EnemyFight");
        Player player = FindFirstObjectByType<Player>();
        int diceRollEnemy = Random.Range(1, 7);
        int diceRollPlayer = Random.Range(1, 7);
        int enemySpeed = speed + diceRollEnemy;
        int playerSpeed = player.speed + diceRollPlayer;

        if (diceRollEnemy == 6 && diceRollPlayer == 1)
        {
            criticalHit = true;
            int damageTaken = (strength + Random.Range(1, 7)) * 2;
            player.TakeDamage(damageTaken);
            Debug.Log("Critical Hit! You've suffered " + damageTaken + "HP damage!");
            damageUI.text = "<#FF0000>Critical hit!</color> You lost <#FFFFFF>" + damageTaken + "HP!</color>";
        }
        else if (diceRollEnemy == 1 && diceRollPlayer == 6)
        {
            criticalFailure = true;
            int damageTaken = strength + Random.Range(1, 7);
            TakeDamage(damageTaken);
            Debug.Log("Critical Failure! The enemy has suffered " + damageTaken + "HP damage!");
            damageUI.text = "<#FF0000>Critical Failure!</color> Enemy lost <#FFF600>" + damageTaken + "HP!</color>";
        }
        else if (!criticalFailure && !criticalHit && enemySpeed <= playerSpeed)
        {
            Debug.Log("Miss");
            damageUI.text = "<#FF0000>Miss!</color>";
        }
        else if (!criticalFailure && !criticalHit && enemySpeed > playerSpeed)
        {
            int damageTaken = strength + Random.Range(1, 7);
            player.TakeDamage(damageTaken);
            Debug.Log("Hit! You've suffered " + damageTaken + "HP damage");
            damageUI.text = "<#FF0000>Hit!</color> You lost <#FFFFFF>" + damageTaken + "HP!</color>";
        }
        else
            damageUI.text = " ";

        return;
    }
    public void CheckIfDead()
    {
        if (currentHp <= 0)
        {
            Player player = FindFirstObjectByType<Player>();
            player.maxXp += 10;
            player.currentXp += 10;
            isDead = true;
            Destroy(gameObject);
        }
    }
    void Update()
    {
        CheckIfDead();
        GetTMP();
    }
}
