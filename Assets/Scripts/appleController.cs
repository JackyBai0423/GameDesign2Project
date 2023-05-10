using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleController : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag == "Player"){
            Destroy(gameObject);
            // Debug.Log("should destroy");
            ScoreScript.scoreVal += 100;
        }
        if (other.tag == "Player2"){
            Destroy(gameObject);
            // Debug.Log("should destroy");
            ScoreScriptAI.scoreVal += 100;
        }
    }
}
