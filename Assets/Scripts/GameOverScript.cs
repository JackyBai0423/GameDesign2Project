using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public static bool isPlayable = true;

    void start() {
        isPlayable = true;
    }

    public void Setup(int score) {
        gameObject.SetActive(true);
        if (ScoreScript.scoreVal > ScoreScriptAI.scoreVal && score > 1000){
        pointsText.text = " P1 wins with " + score.ToString() + " Points";
        isPlayable = false;
        }
        else if (ScoreScriptAI.scoreVal > ScoreScript.scoreVal && score > 1000){
        pointsText.text = " P2 wins with " + score.ToString() + " Points";
        isPlayable = false;
        }
    }

    public void RestartButton(){
        SceneManager.LoadScene("MainGame");
        isPlayable = true;
    }
}
