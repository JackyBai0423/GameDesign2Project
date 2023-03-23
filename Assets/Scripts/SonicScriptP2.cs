using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonicScriptP2 : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask Isles;
    public LayerMask blocker;
    public bool isMoving;
    private Vector2 input;
    // public static int turnCounterP1;
    public static int turnCounterP2;
    // public static bool turnP1;
    public static bool turnP2;
    public static bool walkable;

    // Start is called before the first frame update
    void Start()
    {
        walkable = true;
        // turnCounterP1 = 0;
        // turnP1 = true;
        // turnCounterP2 = 0;
        // turnP2 = true;
        gameObject.name = "Sonic";
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // Debug.Log("input.x " + input.x);

            if (input.x!=0) input.y = 0;

            if(input != Vector2.zero)
            {
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

            if (turnCounterP2 >= 3){
                    turnP2 = false;
                    if (SonicScript.turnP1 == false){
                    SonicScript.turnCounterP1 = 0;
                    }
                    SonicScript.turnP1 = true;
                }
            if (isWalkable(targetPos) && turnP2 == true){
                StartCoroutine(Move(targetPos));
                }
            if(CheckForEncounters(targetPos) && Input.GetKeyDown(KeyCode.Space)) {
                    ScoreScript.scoreVal += 100;
                }

                // Debug.Log("turnP2 in p2 " + turnP2);
                // Debug.Log("turnP1 in p2 "+SonicScript.turnP1);
                // Debug.Log("turn p2 counter " + turnCounterP2);

            // if (turnP2 == true){
            //     // yield return new WaitForSeconds(3);
            //     turnP1 = true;
            //     turnCounterP1 = 0;
            //     }
            }
        }
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

        // if (turnP2 == true){
        //     // yield return new WaitForSeconds(3);
        //     // turnP2 = false;
        //     // turnP1 = true;
        //     turnCounterP2 += 1;

        //     if (turnCounterP2 >= 3){
        //         turnP2 = false;
        //         turnP1 = true;
        //         turnCounterP1 = 0;
        //         }
        //     }

        turnCounterP2 += 1;

        isMoving = false;

        // CheckForEncounters();
    }

    private bool isWalkable(Vector3 targetPos){

        if (Physics2D.OverlapCircle(targetPos, 0.3f, Isles) != null) {
            walkable = false;
            return walkable;
        }
        if (Physics2D.OverlapCircle(targetPos, 0.5f, blocker) != null) {
            walkable = false;
            return walkable;
        }
        if (targetPos.x > 10 || targetPos.x < -10 || targetPos.y > 4 || targetPos.y < -4){
            walkable = false;
            return walkable;
        }
        // Debug.Log(targetPos);
        walkable = true;
        return walkable;
    }

    public bool CheckForEncounters(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.5f, Isles) != null)
        {
            return false;
        }
        return true;
    }
}
