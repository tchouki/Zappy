using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialog : MonoBehaviour
{

    public Text getText;
    public Text Dialog_field;

    public GameObject Dialog;
    public AudioSource Sound;
    // Start is called before the first frame update
    public void sendDialog()
    {
        Dialog.SetActive(true);
        Dialog_field.text = getText.text;
        Sound.Play();
    }

    public void desactiveDialog()
    {
        Dialog.SetActive(false);
    }
}
