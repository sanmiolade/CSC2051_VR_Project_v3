using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // ← ADD THIS LINE
public class PC_Case_CodeActions : MonoBehaviour
{
    // Start is called before the first frame update
    public float activationDelay = 5f;
     private XRGrabInteractable grabInteractable;
    void Start()
    {
        //first disable the PC Casing Socket so Cover can fall over
        XRSocketInteractor socket = GetComponent<XRSocketInteractor>(); //get the Interactor
        // Start with socket disabled
        //socket.enabled = false;
        // Enable the Socket  after delay     
        //Invoke(nameof(EnableSocket), activationDelay);
    }

    // Update is called once per frame
    void Update()
    {

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
            (GetComponent<Rigidbody>()).constraints = RigidbodyConstraints.None;  //activate all physics laws
        Debug.Log($"{gameObject.name} is about to be dropped!");
        // This is the last callback you get before it’s free in the scene
    }


    //************************** Custome Private functions  *********************************


    private void EnableSocket()
    {
        XRSocketInteractor socket = GetComponent<XRSocketInteractor>();
        socket.enabled = true;
        Debug.Log("Socket now enabled!");
    }    
    
    //************************** C  *********************************
}
