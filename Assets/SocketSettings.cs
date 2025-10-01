using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // ← ADD THIS LINE

public class xxxxSocketSettings : MonoBehaviour
{

    public float activationDelay = 5f;
    void Start()
    {
        XRSocketInteractor socket = GetComponent<XRSocketInteractor>();
        //socket.enabled = false;

        // Start with socket disabled
        socket.enabled = false;

        // Enable after delay     
        Invoke(nameof(EnableSocket), activationDelay);
    }
    

    private void EnableSocket()
    {
        XRSocketInteractor socket = GetComponent<XRSocketInteractor>();
        socket.enabled = true;
        Debug.Log("Socket now enabled!");
    }    
}