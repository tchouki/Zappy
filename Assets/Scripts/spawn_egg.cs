using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawn_egg : MonoBehaviour
{
    public GameObject egg;
    public Text x;
    public Text z;

    public void spawnEgg()
    {
        Instantiate(egg, new Vector3(int.Parse(x.text) - 5, 0.5f, int.Parse(z.text) + 4), Quaternion.Euler(new Vector3(0,180,0)));
    }

}
