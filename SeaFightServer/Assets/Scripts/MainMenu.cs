using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public InputField nameInputField;
    public InputField passwordInputField;
    public InputField emailInputField;

    public void Register()
    {
        string name = nameInputField.text;
        string password = passwordInputField.text;
        string email = emailInputField.text;

        StartCoroutine(SendRegistrationData(name, password, email));
    }

    private IEnumerator SendRegistrationData(string name, string password, string email)
    {
        // Erstelle die POST-Daten
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("password", password);
        form.AddField("email", email);

        // Sende die POST-Anfrage an das PHP-Skript
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/PiratenTest/register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError("Fehler beim Senden der Anfrage: " + www.error);
            }
            else
            {
                // Gib den Text der Webseite auf der Konsole aus
                Debug.Log("Antwort vom Server: " + www.downloadHandler.text);
            }
        }
    }
}