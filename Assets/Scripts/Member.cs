using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Member : MonoBehaviour
{
    private bool isPlaced;
    private enum Type { Andrew, Blitz, Fizz };
    private Type type;
    public int coordX, coordy;
    private int moveLeft;

    // initialize member
    void Init(Type type) { 
        this.isPlaced = false;
        this.type = type;
        this.coordX = -1;
        this.coordy = -1;
    }
    // make a move and return whether the move is performed
    bool Move(int destX, int destY) {
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
        else {
            // TO-DO: move it
            moveLeft = 0;
            return true;
        }
    }
}
