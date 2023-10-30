using Riptide;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject startMenu;

    private void Awake()
    {
        startMenu.SetActive(true);
    }

    private static MainMenu _singleton;
    public static MainMenu Singleton
    {
        get => _singleton;
        private set
        {
            if (_singleton == null)
                _singleton = value;
            else if (_singleton != value)
            {
                Debug.Log($"{nameof(MainMenu)} instance already exists, destroying duplicate!");
                Destroy(value);
            }
        }
    }

    public string IPAdress = "127.0.0.1";
    public GameObject Register;
    public GameObject Login;
    public GameObject StartMenu;

    public InputField Register_Name;
    public InputField Register_Email;
    public InputField Register_Password;
    public InputField Login_Name;
    public InputField Login_Password;
    public GameObject Anmeldung;
    public Text Output;


    public void connect()
    {
        Anmeldung.SetActive(false);
        NetworkManager.Singleton.Connect();
    }

    public void connectRetry()
    {
        Anmeldung.SetActive(true);
    }

    public void open_register()
    {
        Output.text = "";
        Register.SetActive(true);
        Login.SetActive(false);
    }

    public void open_login()
    {
        StartMenu.SetActive(false);
        Output.text = "";
        Register.SetActive(false);
        Login.SetActive(true);
    }

    public void SendLogin()
    {
        string type;
        if (Login.activeSelf)
        {
            type = "Login";
        }
        else
        {
            type = "Register";
        }
        
        Output.text = "";
        Message message = Message.Create(MessageSendMode.Reliable, (ushort)ClientToServerId.Login);
        message.AddString(type);
        if (type == "Login")
        {
            message.AddString(Login_Name.text);
            message.AddString("");
            message.AddString(Login_Password.text);
        }
        else
        {
            message.AddString(Register_Name.text);
            message.AddString(Register_Email.text);
            message.AddString(Register_Password.text);
        }
        NetworkManager.Singleton.Client.Send(message);
    }



    [MessageHandler((ushort)ServerToClientId.startInformations)]
    private static void startInformations(Message message)
    {
        string result = message.GetString();
        string[] args = result.Split(";");
        Debug.Log("Result: "+result);
        Debug.Log("args0: "+ args[0]);

        if (args[0].Trim() == "1")
        {

            Debug.Log("Anmeldung erfolgreich");
            GameObject.FindWithTag("MainMenu").gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Anmeldung fehlgeschlagen");
        }
    }





}
