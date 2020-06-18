using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject character;
    static private float angle = 270;
    static private Vector3 pos;
    static float t;
    static float timeToReachTarget;
    static Vector3 startPosition;
    public Animator anim;

    void Start()
    {
        startPosition = character.transform.position;
        pos = startPosition;
        t = 0;
        timeToReachTarget = 1.5f;
    }

    void Update()
    {
        t += Time.deltaTime/1.5f;
        Debug.Log($"Exception occured on connection: {t}");
        character.transform.position = Vector3.Lerp(startPosition, pos, t);
        if (character.transform.position != pos)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    public void Incantation()
    {
        anim.SetBool("isIncantation", !anim.GetBool("isIncantation"));
    }

    public void MoveCharacter()
    {
        startPosition = character.transform.position;
        t = 0;
        if (angle == 0)
        {
            pos = new Vector3 (character.transform.position.x, character.transform.position.y, character.transform.position.z + 1);

        }
        if (angle == 90)
        {
            pos = new Vector3 (character.transform.position.x + 1, character.transform.position.y, character.transform.position.z);

        }
        if (angle == 180)
        {
            pos = new Vector3 (character.transform.position.x, character.transform.position.y, character.transform.position.z - 1);

        }
        if (angle == 270)
        {
            pos = new Vector3 (character.transform.position.x - 1, character.transform.position.y, character.transform.position.z);
        }
    }

    public void LeftCharacter()
    {
        angle -= 90;
        if (angle == -90)
        {
            angle = 270;
        }
        character.transform.eulerAngles = new Vector3 (0, angle, 0);
    }

    public void RightCharacter()
    {
        angle += 90;
        if (angle == 360)
        {
            angle = 0;
        }
        character.transform.eulerAngles = new Vector3 (0, angle, 0);
    }
}
