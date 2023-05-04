using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapeController : MonoBehaviour
{

    public LayerMask Items;

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag == "Player"){
            Destroy(gameObject);
            Debug.Log("should destroy");
            ScoreScript.scoreVal += 200;
        }
        if (other.tag == "Player2"){
            Destroy(gameObject);
            Debug.Log("should destroy");
            ScoreScriptAI.scoreVal += 200;
        }
    }


    // private void OnTriggerEnter2D(Collider2D collision) {

    // if (collision.tag == "Player"){
    void update()
    {
        Debug.Log("entered update");
        // if (Physics2D.OverlapCircle(SonicScript.targetPos, 0.1f, Items) != null)
        // {
        //     Destroy(gameObject);
        //     ScoreScript.scoreVal += 100;
        //     Debug.Log("should destroy");
        // }
    }
    // }
}
