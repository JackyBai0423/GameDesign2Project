using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Member : MonoBehaviour
{
    private bool isPlaced;
    private enum Type { Andrew, Blitz, Fizz };
    private Type type;
    void Init(Type type) { 
        isPlaced = false;
        this.type = type;
    }
}
