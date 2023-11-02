using UnityEngine;
using TMPro;
using Riptide;

public class LoginMenu : MonoBehaviour
{
    [SerializeField] private GameObject _registerMenu;
    [Header("Input Fields")]
    [SerializeField] private TMP_InputField _name;
    [SerializeField] private TMP_InputField _password;

    public void SwitchToRegistermenu()
    {
        gameObject.SetActive(false);
        _registerMenu.SetActive(true);
    }

    public void SendLogin()
    {
        Message message = Message.Create(MessageSendMode.Reliable, (ushort)ClientToServerId.Login);

        message.AddString("Login");
        message.AddString(_name.text);
        message.AddString("");
        message.AddString(_password.text);
        
        NetworkManager.Singleton.Client.Send(message);
    }

    [MessageHandler((ushort)ServerToClientId.startInformations)]
    private static void StartInformations(Message message)
    {
        string result = message.GetString();
        string[] args = result.Split(";");
        Debug.Log("Result: " + result);
        Debug.Log("args0: " + args[0]);

        if (args[0].Trim() == "1")
        {
            Debug.Log("Login successful!");
            UIManager.Singleton.hasLoggedIn = true;
        }
        else
        {
            Debug.Log("Login failed!");
        }
    }
    
}