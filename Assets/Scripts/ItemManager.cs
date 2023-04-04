using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    [SerializeField] public GameObject itemPrefab;
    [SerializeField] public int x, y;
    public List<Item> items; // for further access of items
    // Start is called before the first frame update
    void Start()
    {
        items = new List<Item>();
        GenerateItem(x, y); // for testing just generate one item
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateItem(int x, int y) { 
        Vector2 pos = new Vector2(x-0.5f, y-0.5f); // offset to center the item
        GameObject item = Instantiate(itemPrefab, pos, Quaternion.identity);
        items.Add(item.GetComponent<Item>()); // add the item to the list
    }
}
