using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public bool isWalkable, hasItem;
    private GridManager gridManager;
    public int coordX, coordy;
    [SerializeField] GameObject highlight;

    public void Init(int x, int y)
    {
        hasItem = false;
        coordX = x;
        coordy = y;
        if(mapGenWalkGrid(x,y))
        {
            isWalkable = false;
        }
        else
        {
            isWalkable = true;
        }
        // get the sprite render
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        // set the sprite to the background image
        if (isWalkable)
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("StoreFloor");
        }
        else
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("AisleFreezer");
        }
    }
    private bool mapGenWalkGrid(int x, int y) {
        return x >= 1 && x < 15 && x % 2 != 0 && y >= 1 && y <= 7 && y != 4;
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
