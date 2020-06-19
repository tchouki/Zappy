using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player
{
    public int X;
    public int Y;
    public int n;
    public int O;

    public player(int x, int y, int _n, int o)
    {
        X = x;
        Y = y;
        n = _n;
        O = o;
    }
}

public class team
{
    public string name;
    public List<player> players = new List<player>();

    public team(string teamName)
    {
        name = teamName;
    }

    public void addPlayer(player newPlayer)
    {
        players.Add(newPlayer);
    }
}

public class egg
{
    public int X;
    public int Y;
    public int e;
    public string teamName;

    public egg(int x, int y, int _e, string _teamName)
    {
        X = x;
        Y = y;
        e = _e;
        teamName = _teamName;
    }
}

public class cube
{
    public int X;
    public int Y;
    public int nbr_q0;
    public int nbr_q1;
    public int nbr_q2;
    public int nbr_q3;
    public int nbr_q4;
    public int nbr_q5;
    public int nbr_q6;

    public cube(int x, int y, int _nbr_q0, int _nbr_q1, int _nbr_q2, int _nbr_q3, int _nbr_q4, int _nbr_q5, int _nbr_q6)
    {
        X = x;
        Y = y;
        nbr_q0 = _nbr_q0;
        nbr_q1 = _nbr_q1;
        nbr_q2 = _nbr_q2;
        nbr_q3 = _nbr_q3;
        nbr_q4 = _nbr_q4;
        nbr_q5 = _nbr_q5;
        nbr_q6 = _nbr_q6;
    }

    public void addRessources(int _nbr_q0, int _nbr_q1, int _nbr_q2, int _nbr_q3, int _nbr_q4, int _nbr_q5, int _nbr_q6)
    {
        nbr_q0 = _nbr_q0;
        nbr_q1 = _nbr_q1;
        nbr_q2 = _nbr_q2;
        nbr_q3 = _nbr_q3;
        nbr_q4 = _nbr_q4;
        nbr_q5 = _nbr_q5;
        nbr_q6 = _nbr_q6;   
    }

    public void removeRessource(int nbr)
    {
        if (nbr == 0)
            nbr_q0--;
        if (nbr == 1)
            nbr_q1--;
        if (nbr == 2)
            nbr_q2--;
        if (nbr == 3)
            nbr_q3--;
        if (nbr == 4)
            nbr_q4--;
        if (nbr == 5)
            nbr_q5--;
        if (nbr == 6)
            nbr_q6--;
    }

    public void dropRessource(int nbr)
    {
        if (nbr == 0)
            nbr_q0++;
        if (nbr == 1)
            nbr_q1++;
        if (nbr == 2)
            nbr_q2++;
        if (nbr == 3)
            nbr_q3++;
        if (nbr == 4)
            nbr_q4++;
        if (nbr == 5)
            nbr_q5++;
        if (nbr == 6)
            nbr_q6++;
    }
}

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

public class handleCommands : MonoBehaviour
{
    public GameObject egg;
    public GameObject player;
    public GameObject block;
    public GameObject Q0;
    public GameObject Q1;
    public GameObject Q2;
    public GameObject Q3;
    public GameObject Q4;
    public GameObject Q5;
    public GameObject Q6;
    public int TimeUnit;
    public string TeamName;

    public List<egg> all_eggs;
    public List<team> all_teams;
    public map all_blocks;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MSG_MSZ(int x, int y)
    {
        all_blocks = new map(x, y);
        for (int i = 0; i < x; i++) {
            for (int j = 0; j < y; j++) {
                Instantiate(block, new Vector3(i, 0, j), Quaternion.Euler(new Vector3(0,0,0)));
                all_blocks.addCube(new cube(i, j, 0, 0, 0, 0, 0 , 0, 0));
            }
        }
    }

    void MSG_BCT(int X, int Y, int q0, int q1, int q2, int q3, int q4, int q5, int q6)
    {
        for (int i = 0; i < q0; i++)
            Instantiate(Q0, new Vector3(X, 0, Y), Quaternion.Euler(new Vector3(0,0,0)));
        for (int i = 0; i < q1; i++)
            Instantiate(Q1, new Vector3(X, 0, Y), Quaternion.Euler(new Vector3(0,0,0)));
        for (int i = 0; i < q2; i++)
            Instantiate(Q2, new Vector3(X, 0, Y), Quaternion.Euler(new Vector3(0,0,0)));
        for (int i = 0; i < q3; i++)
            Instantiate(Q3, new Vector3(X, 0, Y), Quaternion.Euler(new Vector3(0,0,0)));
        for (int i = 0; i < q4; i++)
            Instantiate(Q4, new Vector3(X, 0, Y), Quaternion.Euler(new Vector3(0,0,0)));
        for (int i = 0; i < q5; i++)
            Instantiate(Q5, new Vector3(X, 0, Y), Quaternion.Euler(new Vector3(0,0,0)));
        for (int i = 0; i < q6; i++)
            Instantiate(Q6, new Vector3(X, 0, Y), Quaternion.Euler(new Vector3(0,0,0)));
        
        foreach (var cube in all_blocks.all) {
            if (cube.X == X && cube.Y == Y) {
                cube.addRessources(q0, q1, q2, q3, q4, q5, q6);
            }
        }
    }

    void MSG_SGT(int T)
    {
        TimeUnit = T;
    }

    void MSG_TNA(string name)
    {
        all_teams.Add(new team(name));
    }

    void MSG_PWN(int n, int X, int Y, int O, int L, string N)
    {
        Vector3 orientation = new Vector3(0, 0, 0);

        if (O == 1)
            orientation = new Vector3(0, 0, 0);
        if (O == 2)
            orientation = new Vector3(0, 90, 0);
        if (O == 3)
            orientation = new Vector3(0, 180, 0);
        if (O == 4)
            orientation = new Vector3(0, 270, 0);
        Instantiate(player, new Vector3(X, 0, Y), Quaternion.Euler(orientation));
        foreach (var team in all_teams) {
            if (team.name == N) {
                team.addPlayer(new player(X, Y, n, O));
            }
        }
    }

    void MSG_PPO(int n, int X, int Y, int O)
    {
        foreach (var team in all_teams) {
            foreach (var player in team.players) {
                if (n == player.n) {
                    player.X = X;
                    player.Y = Y;
                    player.O = O;
                    return;
                }
            }
        }
    }

    void MSG_PDI(int n)
    {
        foreach (var team in all_teams) {
            foreach (var player in team.players) {
                if (player.n == n) {
                    team.players.Remove(player);
                }
            }
        }
    }

    void MSG_PBC(int n, string M)
    {
    }

    void MSG_PIN(int n, int X, int Y, int q0, int q1, int q2, int q3, int q4, int q5, int q6)
    {
    }

    void MSG_PGT(int n, int i)
    {
        int newX = 0;
        int newY = 0;

        foreach (var team in all_teams) {
            foreach (var player in team.players) {
                if (player.n == n) {
                    newX = player.X;
                    newY = player.Y;
                }
            }
        }
        foreach (var block in all_blocks.all) {
            if (block.X == newX && block.Y == newY) {
                block.removeRessource(i);
            }
        }
    }

    void MSG_PDR(int n, int i)
    {
        int newX = 0;
        int newY = 0;

        foreach (var team in all_teams) {
            foreach (var player in team.players) {
                if (player.n == n) {
                    newX = player.X;
                    newY = player.Y;
                }
            }
        }
        foreach (var block in all_blocks.all) {
            if (block.X == newX && block.Y == newY) {
                block.dropRessource(i);
            }
        }
    }

    void MSG_PEX(int n)
    {
        foreach (var team in all_teams) {
            foreach (var player in team.players) {
                if (player.n == n) {
                    team.players.Remove(player);
                }
            }
        }
    }

    void MSG_PIC(int X, int Y, int L, int n)
    {
    }

    void MSG_PIE(int X, int Y, int R)
    {
    }

    void MSG_PFK(int n)
    {
        int newX = 0;
        int newY = 0;

        foreach (var team in all_teams) {
            foreach (var player in team.players) {
                if (player.n == n) {
                    newX = player.X;
                    newY = player.Y;
                }
            }
        }
        //all_eggs.Add(new egg(newX, newY));
    }

    void MSG_ENW(int e, int n, int X, int Y)
    {
        
    }

    void MSG_EHT(int e)
    {
    }

    void MSG_EBO(int e)
    {
    }

    void MSG_SEG(string N)
    {
    }
}
