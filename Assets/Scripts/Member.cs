using System;
using UnityEngine;

public class Member : MonoBehaviour
{
    public bool isPlaced { get; set; }
    public enum Type { Andrew, Sonic, Fizz };
    public Type type { get; set; }
    public int coordX { get; set; }
    public int coordy { get; set; }
    private int moveLeft { get; set; }

    [SerializeField] private GameObject highlight;

    public void Init(int x, int y, Type type)
    {
        this.isPlaced = false;
        this.type = type;
        this.coordX = -1;
        this.coordy = -1;
        if (type == Type.Andrew)
        {
            this.moveLeft = 1;
        }
        else if (type == Type.Fizz)
        {
            this.moveLeft = 1;
        }
        else
        {
            this.moveLeft = 3;
        }
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (this.type == Type.Andrew)
        {
            renderer.sprite = Resources.Load<Sprite>("ANDREW");
        }
        else if (this.type == Type.Sonic)
        {
            renderer.sprite = Resources.Load<Sprite>("Sonic");
        }
        else if (this.type == Type.Fizz)
        {
            renderer.sprite = Resources.Load<Sprite>("Fizz");
        }
        Instantiate(this, new Vector3(x, y), Quaternion.identity);
    }

    // make a move and return whether the move is performed
    public bool Move(int destX, int destY)
    {
        // if not placed yet, place it
        if (!this.isPlaced)
        {
            // TO-DO: place it
            moveLeft = 0;
            return true;
        }
        else if (Math.Abs(destX - coordX) + Math.Abs(destY - coordy) > moveLeft)
        {
            return false;
        }
        else
        {
            // TO-DO: move it
            moveLeft = 0;
            return true;
        }
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
