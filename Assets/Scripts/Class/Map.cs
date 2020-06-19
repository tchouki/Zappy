using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map
{
    public int X;
    public int Y;
    public List<cube> all = new List<cube>();

    public map(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void addCube(cube newCube)
    {
        all.Add(newCube);
    }
}