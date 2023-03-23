using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnManager : MonoBehaviour
{
    public TextMeshProUGUI turn;
    // Start is called before the first frame update
    void Start()
    {
        turn = GetComponent<TextMeshProUGUI> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (SonicScript.turnP1){
            turn.text = "Player 1's turn";
            if (SonicScript.turnCounterP1 == 3){
                turn.text = "Player 2's turn";    
            }
        }
        if (SonicScriptP2.turnP2){
            turn.text = "Player 2's turn";
            if (SonicScriptP2.turnCounterP2 == 3){
                turn.text = "Player 1's turn";
            }
        }

        if (ScoreScript.scoreVal == 1000 && ScoreScript.scoreVal > ScoreScriptAI.scoreVal){
            turn.text = "Player 1 wins";
        }

        if (ScoreScriptAI.scoreVal == 1000 && ScoreScript.scoreVal < ScoreScriptAI.scoreVal){
            turn.text = "Player 2 wins";
        }
    }
}
