using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class egg
{
    public int X;
    public int Y;
    public int e;
    public string teamName;
    public GameObject Egg;

    public egg(int x, int y, int _e, string _teamName, GameObject _egg)
    {
        X = x;
        Y = y;
        e = _e;
        teamName = _teamName;
        Egg = _egg;
    }
}