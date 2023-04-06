using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] public int width, height;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform cam;
    [SerializeField] private Item item;
    // initialize a 2d array of tiles with size x and y
    private Dictionary<Vector2, Tile> tiles;
    private Dictionary<Vector2, Item> items;

    private void Awake()
    {
        tiles = new Dictionary<Vector2, Tile>();
        items = new Dictionary<Vector2, Item>();
        GenerateGrids();
    }

    private void Start()
    {

    }
    void GenerateGrids()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Tile tile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                tile.name = $"Tile {x} {y}";
                tile.Init(x, y);
                tiles[new Vector2(x, y)] = tile;
            }
        }
        cam.transform.position = new Vector3(width / 2f - 0.5f, height / 2f - 0.5f, -10);
    }
    public void GenerateItems(int numItems)
    {
        Unity.Mathematics.Random rnd = new Unity.Mathematics.Random((uint)System.DateTime.Now.Ticks);
        for (int i = 0; i < numItems; i++)
        {
            int x = rnd.NextInt(0, width - 1);
            int y = rnd.NextInt(0, height - 1);
            if (GetTile(new Vector2(x, y)).isWalkable && !GetTile(new Vector2(x, y)).hasItem && x != 0 && x != 14)
            {
                Item spawn_item = Instantiate(item, new Vector3(x, y), Quaternion.identity);
                items[new Vector2(x, y)] = spawn_item;
                Debug.Log($"Item {i} generated at {x} {y}");
            }
            else
            {
                i--;
            }
        }
    }

    public Tile GetTile(Vector2 pos)
    {
        if (tiles.ContainsKey(pos))
        {
            return tiles[pos];
        }
        else
        {
            return null;
        }
    }

    public Item GetItem(Vector2 pos)
    {
        if (items.ContainsKey(pos))
        {
            return items[pos];
        }
        else
        {
            return null;
        }
    }
}
