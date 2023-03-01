using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    [SerializeField] public int width, height;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform cam;
    // initialize a 2d array of tiles with size x and y
    public Tile[,] tiles;

    private void Start()
    {
        tiles = new Tile[width, height];
        GenerateGrids();
    }
    void GenerateGrids() { 
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Tile tile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                tile.name = $"Tile {x} {y}";
                tile.Init(x, y);
                tiles[x, y] = tile;
            }
        }
        cam.transform.position = new Vector3(width/2f-0.5f, height/2f-0.5f, -10); 
    }
    void GenerateItems(int numItems) {
        Unity.Mathematics.Random rnd = new Unity.Mathematics.Random((uint)System.DateTime.Now.Ticks);
        // combine 2 pics
        for (int i = 0; i < numItems; i++)
        {
            int x = rnd.NextInt(0, width);
            int y = rnd.NextInt(0, height);
            if (tiles[x, y].isWalkable)
            {
                tiles[x, y].isWalkable = false;
                tiles[x, y].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Grapes");
            }
            else
            {
                i--;
            }
        }
    }
}
