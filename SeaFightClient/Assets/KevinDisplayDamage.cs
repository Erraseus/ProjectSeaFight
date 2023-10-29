using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KevinDisplayDamage : MonoBehaviour
{
    Transform facingCamera;
    void Start()
    {
        facingCamera = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = facingCamera.transform.rotation;

    }
}
