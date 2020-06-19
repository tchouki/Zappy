using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialog : MonoBehaviour
{

    public GameObject _game;
    public Text Dialog_field;

    public GameObject Dialog;
    public AudioSource Sound;
    // Start is called before the first frame update
    private string saveDialog = "";
    void Update()
    {
        if (saveDialog != _game.GetComponent<handleCommands>().dialogMessage) {
            Dialog.SetActive(true);
            Dialog_field.text = _game.GetComponent<handleCommands>().dialogMessage;
            Sound.Play();
            saveDialog = _game.GetComponent<handleCommands>().dialogMessage;
        }
    }

    public void desactiveDialog()
    {
        Dialog.SetActive(false);
    }
}
