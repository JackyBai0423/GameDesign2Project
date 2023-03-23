using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public void Setup(int score) {
        gameObject.SetActive(true);
        if (ScoreScript.scoreVal > ScoreScriptAI.scoreVal && score > 1000){
        pointsText.text = " P1 wins with " + score.ToString() + " Points";
        }
        else if (ScoreScriptAI.scoreVal > ScoreScript.scoreVal && score > 1000){
        pointsText.text = " P2 wins with " + score.ToString() + " Points";
        }
    }
}
