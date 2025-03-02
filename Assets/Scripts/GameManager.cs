using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN_A, ENEMYTURN_B, ENEMYTURN_C, WON, LOST }
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
    public GameObject basicCommandUI;
    [SerializeField] Button infoButton;
    [SerializeField] Button fightButton;
    [SerializeField] GameObject hpSlider;
    [SerializeField] Button backButton;

    Player playerUnit;
    Enemy enemyUnit;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }
    void SetupBattle()
    {
        basicCommandUI.SetActive(true);
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Player>();

        GameObject enemy1GO = Instantiate(enemyRedPrefab, enemyBattleStation1);
        enemyUnit = enemy1GO.GetComponent<Enemy>();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        infoScreen.SetActive(true);
        basicCommandUI.SetActive(false);
        backButton.Select();
    }
    public void UnpauseGame()
    {
        Time.timeScale = 1;
        infoScreen.SetActive(false);
        basicCommandUI.SetActive(true);
        infoButton.Select();
    }
}