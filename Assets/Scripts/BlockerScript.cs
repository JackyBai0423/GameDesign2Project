using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerScript : MonoBehaviour
{
    public GameObject andrew;
    public static int counter = 0;
    public LayerMask Isles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && counter < 3){
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 offset = new Vector3(0,0,10);
            Instantiate(andrew, pos + offset, Quaternion.identity);
            counter += 1;
        }

        if (Physics2D.OverlapCircle(transform.position, 1f, Isles) != null) {
            SonicScript.walkable = false;
        }
    }
}
