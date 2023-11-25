using UnityEngine;
using UnityEngine.EventSystems;
using Riptide;

public class PlayerMovement : MonoBehaviour
{
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) // Wenn der linke Mausklick erfolgt
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            Debug.Log("Klick");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform != null)
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Water"))
                {
                    Message message = Message.Create(MessageSendMode.Reliable, (ushort)ClientToServerId.MovePosition);
                    message.AddVector3(hit.point);
                    NetworkManager.Singleton.Client.Send(message);
                    Debug.Log("Send");
                }
                else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Market"))
                {
                    Debug.Log("Market klick");
                    Message message = Message.Create(MessageSendMode.Reliable, (ushort)ClientToServerId.MovePosition);
                    message.AddVector3(hit.transform.gameObject.GetComponent<Market>().TargetPosition);
                    NetworkManager.Singleton.Client.Send(message);
                    Debug.Log("Send");
                }
            }
            else
                Debug.Log("MisKlick");
        }
        
    }
}