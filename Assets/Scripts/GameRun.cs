using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRun : MonoBehaviour
{
    public bool turn; // true = player, false = enemy
    // Start is called before the first frame update
    void Start()
    {
        turn = true; // player starts first

        
    }

    // Update is called once per frame
    void Update()
    {
        // OnGUI();
    }

    void OnGUI()
    {
        if (turn)
        {
            GUI.Label(new Rect(10, 10, 100, 20), "Player Turn");
        }
        else
        {
            GUI.Label(new Rect(10, 10, 100, 20), "AI Turn");
        }
    }

    void Round() { 
            
    }
}
