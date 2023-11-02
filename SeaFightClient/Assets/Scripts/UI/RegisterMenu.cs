using UnityEngine;
using TMPro;
using Riptide;

public class RegisterMenu : MonoBehaviour
{
    [SerializeField] private GameObject _loginMenu;
    [Header("Input Fields")]
    [SerializeField] private TMP_InputField _name;
    [SerializeField] private TMP_InputField _eMail;
    [SerializeField] private TMP_InputField _password;

    public void SwitchToLoginMenu()
    {
        gameObject.SetActive(false);
        _loginMenu.SetActive(true);
    }

    public void SendRegister()
    {
        Message message = Message.Create(MessageSendMode.Reliable, (ushort)ClientToServerId.Login);

        message.AddString("Register");
        message.AddString(_name.text);
        message.AddString(_eMail.text);
        message.AddString(_password.text);

        NetworkManager.Singleton.Client.Send(message);
    }
}