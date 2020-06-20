using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class handleCommands : MonoBehaviour
{
    public Transform parent;
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
    public Text endText;
    public Text logText;
    public float TimeUnit;
    public List<egg> all_eggs;
    public List<team> all_teams;
    public map all_blocks;
    public GameObject _server;
    public string dialogMessage;
    private string serverMessage;
    private bool finish;    
    float t;
    // Start is called before the first frame update
    void Start()
    {
        finish = false;
        t = 0;
        TimeUnit = 0f;
        all_eggs = new List<egg>();
        all_teams = new List<team>();
        dialogMessage = "";
        serverMessage = _server.GetComponent<sceneController>().receivedMessage;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        serverMessage += _server.GetComponent<sceneController>().receivedMessage;
        if (t >= TimeUnit && finish == false) {
            t = t % 1f;
            int index = serverMessage.IndexOf('\n');
            if (index == -1)
                return;
            string serverAction = serverMessage.Substring(0, index);
            int count = logText.text.Split('\n').Length - 1;
            if (count >= 10)
                logText.text = "";
            logText.text += serverAction + "\n";

            serverMessage = serverMessage.Substring(index + 1);
            string[] tokens = serverAction.Split(' ');
            if (tokens[0] == "msz")
                MSG_MSZ(int.Parse(tokens[1]), int.Parse(tokens[2]));
            if (tokens[0] == "bct")
                MSG_BCT(int.Parse(tokens[1]), int.Parse(tokens[2]), int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7]), int.Parse(tokens[8]), int.Parse(tokens[9]));
            if (tokens[0] == "sgt")
                MSG_SGT(int.Parse(tokens[1]));
            if (tokens[0] == "tna")
                MSG_TNA(tokens[1]);
            if (tokens[0] == "pwn")
                MSG_PWN(int.Parse(tokens[1]), int.Parse(tokens[2]), int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), tokens[6]);
            if (tokens[0] == "ppo")
                MSG_PPO(int.Parse(tokens[1]), int.Parse(tokens[2]), int.Parse(tokens[3]), int.Parse(tokens[4]));
            if (tokens[0] == "pdi")
                MSG_PDI(int.Parse(tokens[1]));
            if (tokens[0] == "pbc")
                MSG_PBC(int.Parse(tokens[1]), serverAction.Substring(5));
            if (tokens[0] == "pgt")
                MSG_PGT(int.Parse(tokens[1]), int.Parse(tokens[2]));
            if (tokens[0] == "pdr")
                MSG_PDR(int.Parse(tokens[1]), int.Parse(tokens[2]));
            if (tokens[0] == "pex")
                MSG_PEX(int.Parse(tokens[1]));
            if (tokens[0] == "pic")
                MSG_PIC(int.Parse(tokens[1]), int.Parse(tokens[2]), int.Parse(tokens[3]), int.Parse(tokens[4]));
            if (tokens[0] == "pie")
                MSG_PIE(int.Parse(tokens[1]), int.Parse(tokens[2]), int.Parse(tokens[3]));
            if (tokens[0] == "pfk")
                MSG_PFK(int.Parse(tokens[1]));
            if (tokens[0] == "eht")
                MSG_EHT(int.Parse(tokens[1]));
            if (tokens[0] == "ebo")
                MSG_EBO(int.Parse(tokens[1]));
            if (tokens[0] == "seg")
                MSG_SEG(tokens[1]);
        }
    }

    void MSG_MSZ(int x, int y)
    {
        all_blocks = new map(x, y);
        for (int i = 0; i < x; i++) {
            for (int j = 0; j < y; j++) {
                Instantiate(block, new Vector3(i, 0, j), Quaternion.Euler(new Vector3(0,0,0)), parent);
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
                    cube.addItem(Instantiate(Q0, new Vector3(X - 0.25f, 0.5f, Y - 0.25f), Quaternion.Euler(new Vector3(0,0,0)), parent));
                for (int i = 0; i < q1; i++)
                    cube.addItem(Instantiate(Q1, new Vector3(X - 0.25f, 0.5f, Y), Quaternion.Euler(new Vector3(0,0,0)), parent));
                for (int i = 0; i < q2; i++)
                    cube.addItem(Instantiate(Q2, new Vector3(X, 0.5f, Y - 0.25f), Quaternion.Euler(new Vector3(0,0,0)), parent));
                for (int i = 0; i < q3; i++)
                    cube.addItem(Instantiate(Q3, new Vector3(X, 0.5f, Y), Quaternion.Euler(new Vector3(0,0,0)), parent));
                for (int i = 0; i < q4; i++)
                    cube.addItem(Instantiate(Q4, new Vector3(X - 0.25f, 0.5f, Y + 0.25f), Quaternion.Euler(new Vector3(0,0,0)), parent));
                for (int i = 0; i < q5; i++)
                    cube.addItem(Instantiate(Q5, new Vector3(X + 0.25f, 0.5f, Y), Quaternion.Euler(new Vector3(0,0,0)), parent));
                for (int i = 0; i < q6; i++)
                    cube.addItem(Instantiate(Q6, new Vector3(X + 0.25f, 0.5f, Y + 0.25f), Quaternion.Euler(new Vector3(0,0,0)), parent));
                return;
            }
        }
    }

    void MSG_SGT(int T)
    {
        TimeUnit = T / 100;
    }

    void MSG_TNA(string name)
    {
        all_teams.Add(new team(name));
    }

    void MSG_PWN(int n, int X, int Y, int O, int L, string N)
    {
        Vector3 orientation = new Vector3(0, 0, 0);

        if (O == 1)
            orientation = new Vector3(0, 180, 0);
        if (O == 2)
            orientation = new Vector3(0, 90, 0);
        if (O == 3)
            orientation = new Vector3(0, 0, 0);
        if (O == 4)
            orientation = new Vector3(0, 270, 0);
        foreach (var team in all_teams) {
            if (team.name == N) {
                team.addPlayer(new player(X, Y, n, O, Instantiate(player, new Vector3(X, 0.5f, Y), Quaternion.Euler(orientation), parent)));
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
                    block.addItem(Instantiate(Q0, new Vector3(newX, 0.5f, newY), Quaternion.Euler(new Vector3(0,0,0)), parent));
                if (i == 1)
                    block.addItem(Instantiate(Q1, new Vector3(newX, 0.5f, newY), Quaternion.Euler(new Vector3(0,0,0)), parent));
                if (i == 2)
                    block.addItem(Instantiate(Q2, new Vector3(newX, 0.5f, newY), Quaternion.Euler(new Vector3(0,0,0)), parent));
                if (i == 3)
                    block.addItem(Instantiate(Q3, new Vector3(newX, 0.5f, newY), Quaternion.Euler(new Vector3(0,0,0)), parent));
                if (i == 4)
                    block.addItem(Instantiate(Q4, new Vector3(newX, 0.5f, newY), Quaternion.Euler(new Vector3(0,0,0)), parent));
                if (i == 5)
                    block.addItem(Instantiate(Q5, new Vector3(newX, 0.5f, newY), Quaternion.Euler(new Vector3(0,0,0)), parent));
                if (i == 6)
                    block.addItem(Instantiate(Q6, new Vector3(newX, 0.5f, newY), Quaternion.Euler(new Vector3(0,0,0)), parent));
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
        foreach (var team in all_teams) {
            foreach (var player in team.players) {
                if (player.X == X && player.Y == Y) {
                    player.Nook.GetComponent<move>().Incantation();
                }
            }
        }
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
                    all_eggs.Add(new egg(newX, newY, n, team.name, Instantiate(egg, new Vector3(newX, 0.5f, newY), Quaternion.Euler(new Vector3(0,180,0)), parent)));
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
        foreach (var _egg in all_eggs) {
            if (_egg.e == e) {
                MSG_PWN(e, _egg.X, _egg.Y, 1, 1, _egg.teamName);
                Destroy(_egg.Egg);
                all_eggs.Remove(_egg);
                return;
            }
        }
    }

    void MSG_SEG(string N)
    {
        finish = true;
        endText.text = "Winner is " + N;
    }
}
