using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class team
{
    public string name;
    public List<player> players = new List<player>();

    public team(string teamName)
    {
        name = teamName;
        players = new List<player>();
    }

    public void addPlayer(player newPlayer)
    {
        players.Add(newPlayer);
    }
}