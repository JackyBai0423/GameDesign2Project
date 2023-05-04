using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonicScript : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask Isles;
    public LayerMask blocker;
    public LayerMask Items;
    public bool isMoving;
    private Vector2 input;
    public static int turnCounterP1;
    // public static int turnCounterP2;
    public static bool turnP1;
    // public static bool turnP2;
    public static bool walkable;
    public static bool updateScore;
    public static Vector2 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        walkable = true;
        turnCounterP1 = 0;
        turnP1 = true;
        // turnCounterP2 = 0;
        // turnP2 = false;
        gameObject.name = "Sonic";
        updateScore = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving && GameOverScript.isPlayable)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // Debug.Log("input.x "+input.x);

            if (input.x!=0) input.y = 0;

            if(input != Vector2.zero)
            {
                targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

            if (turnCounterP1 >= 3){
                    turnP1 = false;
                    if (SonicScriptP2.turnP2 == false){
                    SonicScriptP2.turnCounterP2 = 0;
                    }
                    SonicScriptP2.turnP2 = true;
                    // SturnP2 = true;
                    // turnCounterP2 = 0;
                }
            if (isWalkable(targetPos) && turnP1 == true){
                StartCoroutine(Move(targetPos));
                }
            if(CheckForEncounters(targetPos) && Input.GetKeyDown(KeyCode.Space)) {
                    // Debug.Log("both conditions satisfied");
                    updateScore = true;
                    ScoreScript.scoreVal += 100;
                }
                // Debug.Log("turnP1 in p1 "+ turnP1);
                // Debug.Log("turnP2 in p1 "+SonicScriptP2.turnP2);
                // Debug.Log("turn p1 counter " + turnCounterP1);
            }
        }
        // Debug.Log("no");
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        turnCounterP1 += 1;

        isMoving = false;

    }

    private bool isWalkable(Vector3 targetPos){

        if (Physics2D.OverlapCircle(targetPos, 0.2f, Isles) != null) {
            walkable = false;
            return walkable;
        }
        if (Physics2D.OverlapCircle(targetPos, 0.2f, blocker) != null) {
            walkable = false;
            return walkable;
        }        
        if (targetPos.x > 6.5 || targetPos.x < -6.5 || targetPos.y > 4.5 || targetPos.y < -5.5){
            walkable = false;
            return walkable;
        }
        // Debug.Log(targetPos);
        walkable = true;
        return walkable;
    }

    // private void OnTriggerEnter2D(Collider2D other) {
        
    //     if (other.CompareTag("Grape")){
    //         Debug.Log("colliding");
    //     }

    //     if (other.CompareTag("Apple")){
    //         Debug.Log("colliding");
    //     }

    //     if (other.CompareTag("Pizza")){
    //         Debug.Log("colliding");
    //     }

    // }


    public bool CheckForEncounters(Vector3 targetPos)
    {
        // Debug.Log("targestPos is" + targetPos);
        if (Physics2D.OverlapCircle(targetPos, 0.1f, Items) == null)
        {
            // Debug.Log("overlap!");
            return false;
        }
        return true;
    }
}
