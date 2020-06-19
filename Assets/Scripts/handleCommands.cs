using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public List<egg> all_eggs;
    public List<team> all_teams;
    public map all_blocks;
    public GameObject _server;
    public string dialogMessage;
    
    float t;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        all_eggs = new List<egg>();
        all_teams = new List<team>();
        dialogMessage = "";
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime/2f;
        if (t > 2f && t < 3f) {
            MSG_MSZ(10, 5);
            MSG_BCT(0, 0, 2, 0, 0, 0 ,0 ,0 , 0);
            MSG_BCT(1, 1, 2, 0, 0, 0 ,0 ,0 , 0);
            MSG_BCT(4, 3, 0, 1 ,0, 0, 0 ,0 ,0);
            MSG_TNA("yp");
            MSG_PWN(0, 1, 1, 3, 1, "yp");
            MSG_PWN(1, 5, 3, 3, 1, "yp");
            //MSG_PDI(1);
            //MSG_PGT(0, 0);
            //MSG_PGT(0, 0);
            //MSG_PDR(0, 1);
            //MSG_PFK(0);
            //MSG_EHT(0);
            //MSG_PPO(0, 1, 1, 0);
            //MSG_PBC(0, "yoyoyoyoyoyoyo");
            //MSG_PIC(0, 0, 0, 0);
            t = 10f;
        }
        if (t > 12f && t < 13f) {
            MSG_PPO(0, 0, 0, 1);
            MSG_PPO(1, 9, 4, 1);
            t = 20f;
        }
        Debug.Log(_server.GetComponent<sceneController>().receivedMessage);
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
        foreach (var cube in all_blocks.all) {
            if (cube.X == X && cube.Y == Y) {
                cube.addRessources(q0, q1, q2, q3, q4, q5, q6);
                for (int i = 0; i < q0; i++)
                    cube.addItem(Instantiate(Q0, new Vector3(X, 0.5f, Y), Quaternion.Euler(new Vector3(0,0,0))));
                for (int i = 0; i < q1; i++)
                    cube.addItem(Instantiate(Q1, new Vector3(X, 0.5f, Y), Quaternion.Euler(new Vector3(0,0,0))));
                for (int i = 0; i < q2; i++)
                    cube.addItem(Instantiate(Q2, new Vector3(X, 0.5f, Y), Quaternion.Euler(new Vector3(0,0,0))));
                for (int i = 0; i < q3; i++)
                    cube.addItem(Instantiate(Q3, new Vector3(X, 0.5f, Y), Quaternion.Euler(new Vector3(0,0,0))));
                for (int i = 0; i < q4; i++)
                    cube.addItem(Instantiate(Q4, new Vector3(X, 0.5f, Y), Quaternion.Euler(new Vector3(0,0,0))));
                for (int i = 0; i < q5; i++)
                    cube.addItem(Instantiate(Q5, new Vector3(X, 0.5f, Y), Quaternion.Euler(new Vector3(0,0,0))));
                for (int i = 0; i < q6; i++)
                    cube.addItem(Instantiate(Q6, new Vector3(X, 0.5f, Y), Quaternion.Euler(new Vector3(0,0,0))));
                return;
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
        foreach (var team in all_teams) {
            Debug.Log(team.name);
            if (team.name == N) {
                team.addPlayer(new player(X, Y, n, O, Instantiate(player, new Vector3(X, 0.5f, Y), Quaternion.Euler(orientation))));
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
                    Debug.Log("prev move");
                    player.Nook.GetComponent<move>().MoveCharacter(X, Y, O);
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
                    Destroy(player.Nook);
                    team.players.Remove(player);
                    return;
                }
            }
        }
    }

    void MSG_PBC(int n, string M)
    {
        dialogMessage = M;
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
                return;
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
                if (i == 0)
                    block.addItem(Instantiate(Q0, new Vector3(newX, 0.5f, newY), Quaternion.Euler(new Vector3(0,0,0))));
                if (i == 1)
                    block.addItem(Instantiate(Q1, new Vector3(newX, 0.5f, newY), Quaternion.Euler(new Vector3(0,0,0))));
                if (i == 2)
                    block.addItem(Instantiate(Q2, new Vector3(newX, 0.5f, newY), Quaternion.Euler(new Vector3(0,0,0))));
                if (i == 3)
                    block.addItem(Instantiate(Q3, new Vector3(newX, 0.5f, newY), Quaternion.Euler(new Vector3(0,0,0))));
                if (i == 4)
                    block.addItem(Instantiate(Q4, new Vector3(newX, 0.5f, newY), Quaternion.Euler(new Vector3(0,0,0))));
                if (i == 5)
                    block.addItem(Instantiate(Q5, new Vector3(newX, 0.5f, newY), Quaternion.Euler(new Vector3(0,0,0))));
                if (i == 6)
                    block.addItem(Instantiate(Q6, new Vector3(newX, 0.5f, newY), Quaternion.Euler(new Vector3(0,0,0))));
            }
        }
    }

    void MSG_PEX(int n)
    {
        foreach (var team in all_teams) {
            foreach (var player in team.players) {
                if (player.n == n) {
                    Destroy(player.Nook);
                    team.players.Remove(player);
                }
            }
        }
    }

    void MSG_PIC(int X, int Y, int L, int n)
    {
        foreach (var team in all_teams) {
            foreach (var player in team.players) {
                if (player.n == n) {
                    player.Nook.GetComponent<move>().Incantation();
                }
            }
        }
    }

    void MSG_PIE(int X, int Y, int R)
    {
        //TODO
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
                    all_eggs.Add(new egg(newX, newY, n, team.name, Instantiate(egg, new Vector3(newX, 0.5f, newY), Quaternion.Euler(new Vector3(0,0,0)))));
                }
            }
        }
    }

    void MSG_ENW(int e, int n, int X, int Y)
    {
    }

    void MSG_EHT(int e)
    {
        foreach (var _egg in all_eggs) {
            if (_egg.e == e) {
                Destroy(_egg.Egg);
                all_eggs.Remove(_egg);
                return;
            }
        }
    }

    void MSG_EBO(int e)
    {
        //TODO
    }

    void MSG_SEG(string N)
    {
    }
}
