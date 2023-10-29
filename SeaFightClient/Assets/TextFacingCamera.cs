using UnityEngine;

public class TextFacingCamera : MonoBehaviour
{
    Transform facingCamera;
    void Start()
    {
        facingCamera = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
    }
    void Update()
    {
        transform.rotation = facingCamera.transform.rotation;
    }
}