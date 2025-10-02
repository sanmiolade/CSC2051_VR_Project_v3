using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class stabilizeMotherboard : MonoBehaviour
{

 private XRGrabInteractable grabInteractable;
    // Start is called before the first frame update
    void Start()
    {
        XRSocketInteractor socket = GetComponent<XRSocketInteractor>(); //get the Interactor
         (GetComponent<Rigidbody>()).constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void FixedUpdate()
    {

        Rigidbody rb = GetComponent<Rigidbody>();

        // Stop all movement
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Cancel any forces in the next physics update
        rb.ResetCenterOfMass();
        rb.ResetInertiaTensor();
    }

      void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    void OnEnable()
    {
        grabInteractable.selectExited.AddListener(OnDropped);
    }

    void OnDisable()
    {
        grabInteractable.selectExited.RemoveListener(OnDropped);
    }

    void OnDropped(SelectExitEventArgs args)
    {

           // Rigidbody pcrb = gameObject.GetComponent<Rigidbody>();
            //(GetComponent<Rigidbody>()).constraints = RigidbodyConstraints.None;  //activate all physics laws
     
    }



}
