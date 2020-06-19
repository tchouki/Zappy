using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player
{
    public int X;
    public int Y;
    public int n;
    public int O;
    public GameObject Nook;

    public player(int x, int y, int _n, int o, GameObject _nook)
    {
        X = x;
        Y = y;
        n = _n;
        O = o;
        Nook = _nook;
    }
}