using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Transform character;
    private Vector3 pos;
    float t;
    Vector3 startPosition;
    public Animator anim;

    void Start()
    {
        startPosition = character.position;
        pos = startPosition;
        t = 0;
    }

    void Update()
    {
        t += Time.deltaTime/1.5f;
        character.position = Vector3.Lerp(startPosition, pos, t);
        if (character.position != pos)
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);
    }

    public void Incantation()
    {
        anim.SetBool("isIncantation", !anim.GetBool("isIncantation"));
    }

    public void MoveCharacter(int X, int Y, int O)
    {
        startPosition = character.position;
        t = 0;
        pos = new Vector3 (X, character.position.y, Y);
        if (O == 1)
            character.eulerAngles = new Vector3(0, 0, 0);
        if (O == 2)
            character.eulerAngles = new Vector3(0, 90, 0);
        if (O == 3)
            character.eulerAngles = new Vector3(0, 180, 0);
        if (O == 4)
            character.eulerAngles = new Vector3(0, 270, 0);
    }
}
