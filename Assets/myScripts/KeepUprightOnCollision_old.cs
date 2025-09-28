using System.Collections;
using System.Collections.Generic;


using UnityEngine;                       // Import Unity's core engine library (MonoBehaviour, Debug, etc.)
using UnityEngine.XR.Interaction.Toolkit; // Import XR Interaction Toolkit (provides XRGrabInteractable, XRBaseInteractor, etc.)


// This script keeps a cube or any rectangular object upright only while it is colliding with something.
// Once the collision ends, the cube can behave normally again.
public class KeepUprightOnCollision : MonoBehaviour
{
    private Rigidbody rb;          // Reference to the cube's Rigidbody component
    private bool isColliding = false; // Flag to track whether the cube is currently colliding
    private XRGrabInteractable grabInteractable; // Reference to the XRGrabInteractable component on this GameObject


    // Called once when the script is initialized
    void Awake()
    {
        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();
        // Get the XRGrabInteractable component attached to this GameObject
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Subscribe a custom method (OnGrab) to the "onSelectEntered" event
        // → Fired when a controller grabs this object
        grabInteractable.onSelectEntered.AddListener(OnGrab);

        // Subscribe a custom method (OnRelease) to the "onSelectExited" event
        // → Fired when a controller releases this object
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    // Called automatically by Unity when this object starts colliding with another collider
    void OnCollisionEnter(Collision collision)
    {
        // Set flag to true so we know the object is colliding
        isColliding = true;

        rb.constraints = RigidbodyConstraints.FreezeAll;
        Debug.Log("OnCollisionEnter"); // Print message in Unity Console
    }

    // Called automatically by Unity when this object stops colliding with another collider
    void OnCollisionExit(Collision collision)
    {
        // Reset flag to false when collision ends
        isColliding = false;
        // rb.isKinematic = false;
        // rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None;
         Debug.Log("OnCollisionExit"); // Print message in Unity Console
    }

    // This method is automatically called when the object is grabbed
    // "interactor" is the controller (hand or ray) that grabbed the object
    private void OnGrab(XRBaseInteractor interactor)
    {
        Debug.Log("Object grabbed!"); // Print message in Unity Console

        //remove all the constraints so it can obey physics
        rb.constraints = RigidbodyConstraints.None;
    }

    // This method is automatically called when the object is released
    // "interactor" is the controller (hand or ray) that released the object
    private void OnRelease(XRBaseInteractor interactor)
    {
        Debug.Log("Object released!"); // Print message in Unity Console
        rb.constraints = RigidbodyConstraints.None;
    }

    // Called on every physics update (fixed timestep, good for Rigidbody manipulations)
    // void FixedUpdate()
    // {
    //     // Only keep the cube upright while it is colliding
    //     if (isColliding)
    //     {
    //         // Get the current rotation of the cube in Euler angles (X, Y, Z)
    //         Vector3 euler = transform.rotation.eulerAngles;

    //         // Force cube to stand upright: 
    //         // Set X and Z rotation to 0 (no tilt), keep Y rotation unchanged (still allows turning)
    //         transform.rotation = Quaternion.Euler(0, euler.y, 0);

    //         // Prevent angular velocity from tilting the cube again:
    //         // Zero out X and Z spin, but keep Y spin so it can rotate around upright axis
    //         rb.angularVelocity = new Vector3(0, 0, 0);

    //         // --- Kill horizontal velocity to stop sliding ---
    //         rb.velocity = new Vector3(0, 0, 0);            
    //     }
    // }
}

