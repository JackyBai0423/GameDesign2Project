using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;


public class ItemManager : MonoBehaviour
{

    [SerializeField] public GameObject itemPrefab;
    [SerializeField] public GameObject item;
    [SerializeField] public int x, y;

    public LayerMask Items;
    public List<Item> items; // for further access of items
    // Start is called before the first frame update
    void Start()
    {
        items = new List<Item>();
        GenerateItem(-9, 2);
        int x = Random.Range(-9, 9);
        int y  = Random.Range(-3, 3);
        GenerateItem(x, y);
        x = Random.Range(-9, 9);
        y  = Random.Range(-3, 3);
        GenerateItem(x, y); // for testing just generate one item
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(SonicScript.targetPos, 0.1f, Items) != null){
            // DestroyItem();
            // Debug.Log("overlap");
        }
    }

    public void GenerateItem(int x, int y) { 
        Vector2 pos = new Vector2(x-0.5f, y-0.5f); // offset to center the item
        item = (GameObject) Instantiate(itemPrefab, pos, Quaternion.identity);
        // BoxCollider2D bc = item.AddComponent<BoxCollider2D>();
        // bc.isTrigger = true;
        // item.layer= 8;
        items.Add(item.GetComponent<Item>()); // add the item to the list
    }

    public void DestroyItem () {
        Destroy(item);
        ScoreScript.scoreVal += 100;
    }
}
