using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerScript : MonoBehaviour
{
    public GameObject andrew;
    public static int counterP1 = 0;
    public static int counterP2 = 0;
    public bool toRend;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetMouseButtonDown(0) && SonicScript.turnP1 && counterP1 < 4){
            rend.enabled = toRend;
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 offset = new Vector3(0,0,1);
            Instantiate(andrew, pos + offset, Quaternion.identity);
            counterP1 += 1;
            Debug.Log("Blocker 1 can be placed");

        }

         if(Input.GetMouseButtonDown(0) && SonicScriptP2.turnP2 && counterP2 < 8){
            rend.enabled = toRend;
            Debug.Log("Blocker 2 can be placed");
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 offset = new Vector3(0,0,1);
            Instantiate(andrew, pos + offset, Quaternion.identity);
            counterP2 += 1;
        }


        Debug.Log(TurnManager.turnCounter%4);
        if ((TurnManager.turnCounter % 4) == 0){

        // if (((SonicScript.turnCounterP1 + SonicScriptP2.turnCounterP2) / 16) == ) {
            DestroyObj();
        }

        // Debug.Log("counterP1 is " + counterP1);

        // Debug.Log("counterP2 is " + counterP2);

        // if (Physics2D.OverlapCircle(transform.position, 1f, Isles) != null) {
        //     SonicScript.walkable = false;
        // }
    }

    void DestroyObj(){
        Destroy(gameObject);
    }
}
