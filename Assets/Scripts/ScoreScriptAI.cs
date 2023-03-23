using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScriptAI : MonoBehaviour
{
    public static int scoreVal = 0;
    public TextMeshProUGUI score;
    public bool gameOver;
    public int consecutive = 0;
    public GameOverScript GameOverScreen;

    public void GameOver(){
        GameOverScreen.Setup(scoreVal);
    }
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI> ();
        consecutive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreVal;

        if (Input.GetKeyDown(KeyCode.Space) && SonicScriptP2.turnP2 && !SonicScript.turnP1 && consecutive < 3){
            AddScore();
        }

        if (Input.GetKeyDown(KeyCode.Escape)){
            gameOver = true;
        }

        if (scoreVal >= 1000){
            GameOver();
        }
        if (consecutive == 3 && !SonicScriptP2.turnP2 && SonicScript.turnP1){
            consecutive = 0;
        }

        // if (consecutive > 2){
        //     SonicScriptP2.turnP2 = false;
        //     SonicScript.turnP1 = true;
        //     consecutive = 0;
        // }
    }

    public void AddScore(){
        scoreVal += 100;
        consecutive += 1;
    }
}
