using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
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
    public List<GameObject> ressources;

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
        ressources = new List<GameObject>();
    }

    public void addItem(GameObject _new)
    {
        ressources.Add(_new);
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
        if (nbr == 0) {
            nbr_q0--;
            foreach (var item in ressources) {
                if (item.tag == "Q0") {
                    Destroy(item);
                    ressources.RemoveAt(ressources.IndexOf(item));
                    return;
                }
            }
        }
        if (nbr == 1) {
            nbr_q1--;
            foreach (var item in ressources) {
                if (item.tag == "Q1") {
                    Destroy(item);
                    ressources.RemoveAt(ressources.IndexOf(item));
                    return;
                }
            }
        }
        if (nbr == 2) {
            nbr_q2--;
            foreach (var item in ressources) {
                if (item.tag == "Q2") {
                    Destroy(item);
                    ressources.RemoveAt(ressources.IndexOf(item));
                    return;
                }
            }
        }
        if (nbr == 3) {
            nbr_q3--;
            foreach (var item in ressources) {
                if (item.tag == "Q3") {
                    Destroy(item);
                    ressources.RemoveAt(ressources.IndexOf(item));
                    return;
                }
            }
        }
        if (nbr == 4) {
            nbr_q4--;
            foreach (var item in ressources) {
                if (item.tag == "Q4") {
                    Destroy(item);
                    ressources.RemoveAt(ressources.IndexOf(item));
                    return;
                }
            }
        }
        if (nbr == 5) {
            nbr_q5--;
            foreach (var item in ressources) {
                if (item.tag == "Q5") {
                    Destroy(item);
                    ressources.RemoveAt(ressources.IndexOf(item));
                    return;
                }
            }
        }
        if (nbr == 6) {
            nbr_q6--;
            foreach (var item in ressources) {
                if (item.tag == "Q6") {
                    Destroy(item);
                    ressources.RemoveAt(ressources.IndexOf(item));
                    return;
                }
            }
        }
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