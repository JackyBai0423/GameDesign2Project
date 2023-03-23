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
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI> ();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreVal;

        if (Input.GetKeyDown(KeyCode.Space) && SonicScriptP2.turnP2 == true && SonicScript.turnP1 == false){
             scoreVal += 100;
        }

        if (Input.GetKeyDown(KeyCode.Escape)){
            gameOver = true;
        }
    }

    public void AddScore(){
        scoreVal += 100;
    }
}
