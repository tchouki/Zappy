using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Linq;

public class sceneController : MonoBehaviour
{
    private Button button;
    private Text buttonText;
    public InputField ip, port;
    private Color32 colorBrown = new Color32(0x93, 0x6C, 0x38, 0xFF);

    private static bool CheckIPValid(string ip)
    {
        if (String.IsNullOrWhiteSpace(ip))
        {
            return false;
        }

        string[] splitValues = ip.Split('.');
        if (splitValues.Length != 4)
        {
            return false;
        }

        byte tempForParsing;

        return splitValues.All(r => byte.TryParse(r, out tempForParsing));
    }
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private bool setValidateColor(Image img, bool valid)
    {
        if (!valid)
            img.color = Color.red;
        else
            img.color = colorBrown;
        return (valid);
    }

    public void loadGameScene()
    {
        bool validData;
        Debug.Log("IP: " + ip.text);
        Debug.Log("Port: " + port.text);
        validData = setValidateColor(ip.image, CheckIPValid(ip.text));
        validData = validData && setValidateColor(port.image, int.TryParse(port.text, out _));
        if (validData)
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void loadMenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
