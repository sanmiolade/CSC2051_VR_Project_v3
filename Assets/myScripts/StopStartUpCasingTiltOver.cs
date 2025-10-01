using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
// Reference to the cube's Rigidbody component
public class xxxxStopStartUpCasingTiltOver : MonoBehaviour
{
    // Start is called before the first frame update
    private float startTime;   // Time when the script started
    private bool messageShown; // Ensure the message is only shown once
    private XRBaseInteractable interactable; // Reference to this object's interactable

    private Rigidbody rb;
    private float DELAY_TIME = 25f;
    void Start()
    {
        NeutralizeAllForces();
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
        if (interactable != null)
        {
            // Subscribe to hoverEntered event
            interactable.hoverEntered.AddListener(OnHoverEnter);
            interactable.hoverExited.AddListener(OnHoverExit);
        }
    }

    void OnDisable()
    {
        if (interactable != null)
        {
            // Unsubscribe to avoid memory leaks
            interactable.hoverEntered.RemoveListener(OnHoverEnter);
            interactable.hoverExited.RemoveListener(OnHoverExit);
        }
    }


    void OnHoverExit(HoverExitEventArgs args)
    { /* ... */
        NeutralizeAllForces();
        Debug.Log("FreezeAll Activated");
    }

    // Called when a controller ray starts hovering this object
    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        // Get the current position
        rb = GetComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.None;  //activate all physics laws

        Debug.Log($"{gameObject.name}  on hover!");
        Debug.Log("FreezeAll DEactivated");
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



    public void NeutralizeAllForces()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        // Stop all movement
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Cancel any forces in the next physics update
        rb.ResetCenterOfMass();
        rb.ResetInertiaTensor();

        // Freeze all motion
        rb.constraints = RigidbodyConstraints.FreezeAll;

        // Optional: Also stop any coroutines or custom physics
        StopAllCoroutines();
        Debug.Log("NeutralizeAllForces");
    }



} //end class
