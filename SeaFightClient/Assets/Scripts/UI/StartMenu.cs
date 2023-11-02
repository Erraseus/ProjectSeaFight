using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private GameObject _loginMenu;

    public void Connect()
    {
        _startButton.interactable = false;
        NetworkManager.Singleton.Connect();
    }
    public void ConnectRetry()
    {
        _startButton.interactable = true;
    }
    public void OpenLogin()
    {
        gameObject.SetActive(false);
        _loginMenu.SetActive(true);
    }
}