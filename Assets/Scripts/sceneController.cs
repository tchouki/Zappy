using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneController : MonoBehaviour
{
    private Button button;
    private Text buttonText;
    public InputField
        ip,
        port;
    public Text linkedText;
    private Color32 _colorBrown = new Color32(0x93, 0x6C, 0x38, 0xFF);
    private Server.Server _server;

    public GameObject _menu;
    public GameObject _game;
    private GameObject _saveGame;
    private bool isConnected;
    public string receivedMessage;

    private static bool CheckIPValid(string ip)
    {
        if (String.IsNullOrWhiteSpace(ip))
            return false;
        string[] splitValues = ip.Split('.');
        if (splitValues.Length != 4)
            return false;
        return splitValues.All(r => byte.TryParse(r, out _));
    }
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<Text>();
        _menu.SetActive(true);
        _game.SetActive(false);
        _saveGame = _game;
        isConnected = false;
        receivedMessage = "";

    }

    // Update is called once per frame
    void Update()
    {
        if (isConnected == true) {
            receivedMessage = _server.ReceiveMsg();
        }
        if (Input.GetKeyDown("escape"))
            loadMenuScene();

    }

    private bool SetValidateColor(Image img, bool valid)
    {
        if (!valid)
            img.color = Color.red;
        else
            img.color = _colorBrown;
        return (valid);
    }

    public void loadGameScene()
    {
        Debug.Log("IP: " + ip.text);
        Debug.Log("Port: " + port.text);
        bool validData = SetValidateColor(ip.image, CheckIPValid(ip.text));
        validData = validData && SetValidateColor(port.image, int.TryParse(port.text, out _));
        if (!validData)
            return;
        linkedText.text = "Connection...";
        try {
            _server = new Server.Server(ip.text, port.text);
        } catch (Exception e) {
            Debug.Log($"Exception occured on connection: {e}");
            linkedText.color = Color.red;
            linkedText.fontSize = 27;
            linkedText.text = "An error occured. Double check the IP address and the port.";
            return;
        }
        _menu.SetActive(false);
        _game.SetActive(true);
        isConnected = true;
    }

    public void loadMenuScene()
    {
        _game = _saveGame;
        _menu.SetActive(true);
        _game.SetActive(false);
    }
}
