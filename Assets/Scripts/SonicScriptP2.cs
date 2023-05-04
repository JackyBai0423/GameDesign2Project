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
        if (!isMoving && GameOverScript.isPlayable)
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
            if(PickupItem(targetPos) && Input.GetKeyDown(KeyCode.Space)) {
                    ScoreScript.scoreVal += 100;
                }

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

        turnCounterP2 += 1;

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

    public bool PickupItem(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.1f, Isles) != null)
        {
            return false;
        }
        return true;
    }
}
