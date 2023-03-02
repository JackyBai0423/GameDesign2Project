using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRun : MonoBehaviour
{
    [SerializeField] private GridManager gridManager;
    [SerializeField] private Member member;
    private bool isPlayerTurn; // true for player, false for enemy
    private List<Member.Type> playerHand, enemyHand;

    // Start is called before the first frame update
    void Start()
    {
        playerHand = new List<Member.Type>();
        playerHand.Add(Member.Type.Andrew);
        playerHand.Add(Member.Type.Sonic);
        playerHand.Add(Member.Type.Fizz);
        enemyHand = new List<Member.Type>();
        enemyHand.Add(Member.Type.Andrew);
        enemyHand.Add(Member.Type.Sonic);
        enemyHand.Add(Member.Type.Fizz);
        switchToPlayer(); // player starts first
    }

    // Update is called once per frame
    void Update()
    {
        //// Get the mouse position
        //Vector3 mousePosition = Input.mousePosition;

        //// Get the camera that is rendering the scene
        //Camera camera = Camera.main;

        //// Convert the mouse position to world coordinates
        //Vector3 mousePositionWorld = camera.ScreenToWorldPoint(mousePosition);

        //// Do something with the mouse position in world coordinates
        //Debug.Log("Mouse position in world coordinates: " + mousePositionWorld);
        turnStart();
    }

    void OnGUI()
    {
        if (isPlayerTurn)
        {
            GUI.Label(new Rect(10, 10, 100, 20), "Player Turn");
        }
        else if (!isPlayerTurn)
        {
            GUI.Label(new Rect(10, 10, 100, 20), "AI Turn");
        }
    }
    // give player a turn
    public void switchToPlayer() {
        roundStart();
        isPlayerTurn = true;
    }
    // give AI a turn
    public void switchToAI()
    {
        isPlayerTurn = false;
    }
    // start of a round
    public void roundStart()
    {
        gridManager.GenerateItems(5);
    }

    public void roundEnd()
    {

    }

    public void turnStart()
    {
        //List<Member> currentHand = (isPlayerTurn) ? playerHand : enemyHand;
        //// place all the members on tile
        //for(int i = 0; i < currentHand.Count; i++)
        //{
        //    StartCoroutine(WaitForMouseClick());
        //    Vector3 mousePosition = Input.mousePosition;
        //    Camera camera = Camera.main;
        //    Vector3 mousePositionWorld = camera.ScreenToWorldPoint(mousePosition);
        //    int x = (int)Mathf.Floor(mousePositionWorld.x);
        //    int y = (int)Mathf.Floor(mousePositionWorld.y);
        //    if(((x == 0 && isPlayerTurn) || (x == 14 && !isPlayerTurn)) && gridManager.GetTile(new Vector2(x,y)).isWalkable && !gridManager.GetTile(new Vector2(x, y)).hasItem)
        //    {
        //        Member placed_member = currentHand[0];
        //        currentHand.RemoveAt(0);
        //        placed_member.Init(x, y);
        //    }
        //    else
        //    {
        //        i--;
        //    }
            
        //}
    }

    public void turnEnd()
    {

    }

    private void OnMouseDown()
    {
        List<Member.Type> currentHand = (isPlayerTurn) ? playerHand : enemyHand;
        if(currentHand.Count == 0)
        {
            return;
        }
        Vector3 mousePosition = Input.mousePosition;
        Camera camera = Camera.main;
        Vector3 mousePositionWorld = camera.ScreenToWorldPoint(mousePosition);
        int x = (int)Mathf.Floor(mousePositionWorld.x);
        int y = (int)Mathf.Floor(mousePositionWorld.y);
        Debug.Log($"Mouse down at: {x} {y}");
        if (((x == 0 && isPlayerTurn) || (x == 14 && !isPlayerTurn)) && gridManager.GetTile(new Vector2(x, y)).isWalkable && !gridManager.GetTile(new Vector2(x, y)).hasItem)
        {
            Member placed_member = Instantiate(member,new Vector3(x,y),Quaternion.identity);
            placed_member.Init(x, y, currentHand[0]);
            currentHand.RemoveAt(0);
        }
    }
}
