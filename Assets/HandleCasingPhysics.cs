using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // ← ADD THIS LINE

public class HandleCasingPhysics : MonoBehaviour
{

    private XRGrabInteractable grabInteractable;

    // Start is called before the first frame update    // Start is called before the first frame update
    public float activationDelay = 5f;

    [SerializeField] private XRSocketInteractor socket;

    void Start()
    {

        // Start with socket disabled
        socket.enabled = false;
        // Enable the Socket  after delay     
        //Invoke(nameof(EnableSocket), activationDelay);


                    // Through code:
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;    // Makes it unaffected by physics forces
            rb.constraints = RigidbodyConstraints.FreezeAll; // Extra safety
    }

    // // Update is called once per frame
    // void Update()
    // {

    // }

    // void Awake()
    // {
    //     grabInteractable = GetComponent<XRGrabInteractable>();
    // }

    // void OnEnable()
    // {
    //     grabInteractable.selectExited.AddListener(OnDropped);
    // }

    // void OnDisable()
    // {
    //     grabInteractable.selectExited.RemoveListener(OnDropped);
    // }

    // void OnDropped(SelectExitEventArgs args)
    // {

    //     //Access teh Rigidbody and bring back all its Physics
    //     (GetComponent<Rigidbody>()).constraints = RigidbodyConstraints.None;  //activate all physics laws
    //     Debug.Log($"{gameObject.name} is about to be dropped!");

    // }
    

    //************************** Custome Private functions  *********************************


    private void EnableSocket()
    {
        XRSocketInteractor socket = GetComponent<XRSocketInteractor>();
        socket.enabled = true;
        Debug.Log("Socket now enabled!");
    }    
    
    //************************** C  *********************************    

}
