using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


using UnityEngine.XR.Interaction.Toolkit;

public class CoverSocketHandler : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor socket;
    [SerializeField] private GameObject Pc_Case;
    void OnEnable()
    {
        socket.selectEntered.AddListener(OnCoverAttached);
        socket.selectExited.AddListener(OnCoverDetached);
    }

    void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnCoverAttached);
        socket.selectExited.RemoveListener(OnCoverDetached);
    }

    void OnCoverAttached(SelectEnterEventArgs args)
    {
        print("OnCoverAttached....");
         Debug.Log($"[{DateTime.Now:HH:mm:ss.fff}] OnCoverAttached....");
        Rigidbody rb = args.interactableObject.transform.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Rigidbody pcrb = Pc_Case.GetComponent<Rigidbody>();
            pcrb.constraints = RigidbodyConstraints.FreezeAll; //Stop Casing from moving...
            // Stop all momentum
            // rb.velocity = Vector3.zero;
            // rb.angularVelocity = Vector3.zero;

            // // Disable physics so it won’t push Case A
            // rb.isKinematic = true;
            // rb.velocity = Vector3.zero;
            // rb.angularVelocity = Vector3.zero;            
            // Debug.Log($"[{DateTime.Now:HH:mm:ss.fff}] Kinematic=True....");
        }
    }

    void OnCoverDetached(SelectExitEventArgs args)
    {
        // print("OnCoverDetached....");
        // Debug.Log($"[{DateTime.Now:HH:mm:ss.fff}] OnCoverDetached....");
        // Rigidbody rb = args.interactableObject.transform.GetComponent<Rigidbody>();
        // if (rb != null)
        // {
        //     // Re-enable normal physics when grabbed again
        //     rb.isKinematic = false;
        //      Debug.Log($"[{DateTime.Now:HH:mm:ss.fff}] Kinematic=False....");
        // }
    }
}
