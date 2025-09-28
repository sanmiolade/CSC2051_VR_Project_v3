using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
           // Reference to the cube's Rigidbody component
public class StopStartUpCasingTiltOver : MonoBehaviour
{
    // Start is called before the first frame update
    private float startTime;   // Time when the script started
    private bool messageShown; // Ensure the message is only shown once
    private XRBaseInteractable interactable; // Reference to this object's interactable

    private Rigidbody rb;
    private float DELAY_TIME = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //make sure the game object does not follow laws of physics
        rb.constraints = RigidbodyConstraints.FreezeAll;
        Debug.Log("In Start"); // Print message in Unity Console        
        // Record the time when the game starts (in seconds since the app launched)
        startTime = Time.time;
        messageShown = false;
    }

       void Awake()
    {
        // Get the XRBaseInteractable component (works for XRGrabInteractable too)
        interactable = GetComponent<XRBaseInteractable>();
    }

    void OnEnable()
    {
        // Subscribe to hoverEntered event
        interactable.hoverEntered.AddListener(OnHoverEnter);
    }

    void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        interactable.hoverEntered.RemoveListener(OnHoverEnter);
    }


    // Called when a controller ray starts hovering this object
    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        // Get the current position
            rb = GetComponent<Rigidbody>();

            rb.constraints = RigidbodyConstraints.None;  //activate all physics laws

        Debug.Log($"{gameObject.name}  on hover!");
    }

    void FixedUpdate()
    {
        // Calculate how many seconds have passed since Start()
        float elapsedTime = Time.time - startTime;

        // Check if 20 seconds have passed and message not yet shown
        if (elapsedTime >= DELAY_TIME && !messageShown)
        {
            messageShown = true; // Prevent repeating the message every frame
            rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;  //activate all physics laws
            Debug.Log($"{DELAY_TIME} seconds have passed since the application started AND PC CASE is now obeying Physics!");
            
        }
    }
}
