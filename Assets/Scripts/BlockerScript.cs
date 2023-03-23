using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerScript : MonoBehaviour
{
    public GameObject andrew;
    public static int counterP1 = 0;
    public static int counterP2 = 0;
    public LayerMask Isles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && counterP1 < 3 && SonicScript.turnP1){
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 offset = new Vector3(0,0,1);
            Instantiate(andrew, pos + offset, Quaternion.identity);
            counterP1 += 1;
        }

         if(Input.GetMouseButtonDown(0) && counterP2 < 3  && SonicScriptP2.turnP2){
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 offset = new Vector3(0,0,1);
            Instantiate(andrew, pos + offset, Quaternion.identity);
            counterP2 += 1;
        }

        // if (Physics2D.OverlapCircle(transform.position, 1f, Isles) != null) {
        //     SonicScript.walkable = false;
        // }
    }
}
