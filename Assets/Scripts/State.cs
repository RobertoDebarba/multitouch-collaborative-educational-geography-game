using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {

    public string Name;
    public float X;
    public float Y;

    public State(string name, float x, float y)
    {
        Name = name;
        X = x;
        Y = y;
    }
}
