using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum BattleState { START, PLAYERTURN, ENEMYTURN_A, ENEMYTURN_B, ENEMYTURN_C, WON, LOST }
[DefaultExecutionOrder(1)]
public class GameManager : MonoBehaviour
{
    public BattleState state;
    public GameObject playerPrefab;
    public GameObject enemyRedPrefab;
    public GameObject enemyYellowPrefab;
    public GameObject enemyGreenPrefab;
    public Transform playerBattleStation;
    public Transform enemyBattleStation1;
    public Transform enemyBattleStation2;
    public Transform enemyBattleStation3;
    public GameObject infoScreen;
    public GameObject gameOverScreen;
    public GameObject basicCommandUI;
    public PlayerHUD playerHUD;
    [SerializeField] Button infoButton;
    [SerializeField] Button fightButton;
    [SerializeField] Button restartButton;
    [SerializeField] GameObject hpSlider;
    [SerializeField] Button backButton;
    public GameObject damageUIBox;

    Player playerUnit;
    Enemy enemyUnit1;
    Enemy enemyUnit2;
    Enemy enemyUnit3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
        damageUIBox = GameObject.Find("/UICanvas/DamageUI");
    }
    void SetupBattle()
    {
        basicCommandUI.SetActive(true);
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Player>();

        GameObject enemy1GO = Instantiate(enemyRedPrefab, enemyBattleStation1);
        enemyUnit1 = enemy1GO.GetComponent<Enemy>();

        RollInitiative();
    }
    void Update()
    {
        playerHUD.SetHUD(playerUnit);
        if (playerUnit.isDead == true)
        {
            GameOver();
        }
    }
    public void RollInitiative()
    {

        int playerInitiative = playerUnit.speed + Random.Range(1, 7); ;
        int enemyInitiative = enemyUnit1.speed + Random.Range(1, 7); ;

        Debug.Log("Player: " + playerInitiative.ToString());
        Debug.Log("Enemy: " + enemyInitiative.ToString());

        if (playerInitiative >= enemyInitiative)
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
        else if (playerInitiative < enemyInitiative)
        {
            state = BattleState.ENEMYTURN_A;
            EnemyTurn_A();
        }
    }
    public void ResetCriticals()
    {
        if (playerBattleStation.childCount > 0)
        {
            playerUnit.criticalFailure = false;
            playerUnit.criticalHit = false;
        }
        else
            return;

        if (enemyBattleStation1.childCount > 0)
        {
            enemyUnit1.criticalFailure = false;
            enemyUnit1.criticalHit = false;
        }
        else
            return;

        if (enemyBattleStation2.childCount > 0)
        {
            enemyUnit2.criticalFailure = false;
            enemyUnit2.criticalHit = false;
        }
        else
            return;

        if (enemyBattleStation3.childCount > 0)
        {
            enemyUnit3.criticalFailure = false;
            enemyUnit3.criticalHit = false;
        }
        else
            return;
    }
    public void EnemyTurn_A()
    {
        ResetCriticals();

        StartCoroutine(enemyUnit1.Fight());

        if (enemyBattleStation2.childCount > 0)
        {
            state = BattleState.ENEMYTURN_B;
            EnemyTurn_B();
        }
        else if (enemyBattleStation2.childCount == 0 && playerUnit.isDead == false)
        {
            GameObject enemy2GO = Instantiate(enemyRedPrefab, enemyBattleStation2);
            enemyUnit2 = enemy2GO.GetComponent<Enemy>();

            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    public void EnemyTurn_B()
    {
        ResetCriticals();

        StartCoroutine(enemyUnit2.Fight());

        if (enemyBattleStation3.childCount > 0)
        {
            state = BattleState.ENEMYTURN_C;
            EnemyTurn_C();
        }
        else if (enemyBattleStation3.childCount == 0 && playerUnit.isDead == false)
        {
            GameObject enemy3GO = Instantiate(enemyRedPrefab, enemyBattleStation3);
            enemyUnit3 = enemy3GO.GetComponent<Enemy>();

            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    public void EnemyTurn_C()
    {
        ResetCriticals();

        StartCoroutine(enemyUnit3.Fight());

        if (enemyBattleStation1.childCount == 0 && playerUnit.isDead == false)
        {
            GameObject enemy1GO = Instantiate(enemyRedPrefab, enemyBattleStation1);
            enemyUnit1 = enemy1GO.GetComponent<Enemy>();

            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    public void PlayerTurn()
    {
        ResetCriticals();

        infoButton.Select();
    }
    public void OnFightButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        else
            StartCoroutine(playerUnit.Fight());

        EndPlayerTurn();
    }

    public void EndPlayerTurn()
    {
        if (enemyUnit1.isDead == false && enemyBattleStation1.childCount > 0)
        {
            state = BattleState.ENEMYTURN_A;
            EnemyTurn_A();
        }

        else if (enemyUnit1.isDead == true)
        {
            GameObject enemy1GO = Instantiate(enemyRedPrefab, enemyBattleStation1);
            enemyUnit1 = enemy1GO.GetComponent<Enemy>();

            if (enemyBattleStation2.childCount > 0)
            {
                state = BattleState.ENEMYTURN_B;
                EnemyTurn_B();
            }
            else if (enemyBattleStation2.childCount == 0 && enemyBattleStation3.childCount > 0)
            {
                GameObject enemy2GO = Instantiate(enemyRedPrefab, enemyBattleStation2);
                enemyUnit2 = enemy2GO.GetComponent<Enemy>();

                state = BattleState.ENEMYTURN_C;
                EnemyTurn_C();
            }
            else if (enemyBattleStation2.childCount == 0 && enemyBattleStation3.childCount == 0)
            {
                GameObject enemy3GO = Instantiate(enemyRedPrefab, enemyBattleStation3);
                enemyUnit3 = enemy3GO.GetComponent<Enemy>();

                state = BattleState.PLAYERTURN;
                PlayerTurn();
            }
            else
            {
                state = BattleState.PLAYERTURN;
                PlayerTurn();
            }
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        infoScreen.SetActive(true);
        basicCommandUI.SetActive(false);
        damageUIBox.SetActive(false);
        backButton.Select();
    }
    public void UnpauseGame()
    {
        Time.timeScale = 1;
        infoScreen.SetActive(false);
        basicCommandUI.SetActive(true);
        damageUIBox.SetActive(true);

        if (state == BattleState.PLAYERTURN)
        {
            infoButton.Select();
        }
        else { return; }
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
        basicCommandUI.SetActive(false);
        damageUIBox.SetActive(false);
        restartButton.Select();
    }
}