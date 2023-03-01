using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRun : MonoBehaviour
{
    [SerializeField] private GridManager gridManager;
    public enum GameState { PlayerTurn, EnemyTurn, GameOver };
    public GameState turn; // true = player, false = enemy
    // Start is called before the first frame update
    void Start()
    {
        switchToPlayer(); // player starts first
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (turn == GameState.PlayerTurn)
        {
            GUI.Label(new Rect(10, 10, 100, 20), "Player Turn");
        }
        else if (turn == GameState.EnemyTurn)
        {
            GUI.Label(new Rect(10, 10, 100, 20), "AI Turn");
        }
    }
    // give player a turn
    public void switchToPlayer() {
        roundStart();
        turn = GameState.PlayerTurn;
    }
    // give AI a turn
    public void switchToAI()
    {
        turn = GameState.EnemyTurn;
    }
    // start of a round
    public void roundStart() {
        gridManager.GenerateItems(5);
    }
    public void endRound() { 
    }
}
