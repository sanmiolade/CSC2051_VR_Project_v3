using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CardSocketEventHandlerB : MonoBehaviour
{
    /*FUNCTION 
            This class allow PCI cards to be dropped in any slot and be placed perfectly.
            During design phrase you determine the perfect placement of the Card and store that Card Snap point tranform value
            in the __SocketPlacement GameObject which is kept as a child of the card. As each card will have different __SocketPlacement
            values. This values is copied to the Card_snapPoint object before the card is dropped. See code below
            October 2, 2025 at 01:55am

    */
    private XRSocketInteractor socket;
    private GameObject theNetworkCard;
    private GameObject cardSnapPoint;
    private GameObject CardSoketPlacementValue;
    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();

        // Subscribe to events
        //socket.hoverEntering.AddListener(OnHoverEntering);
        socket.hoverEntered.AddListener(OnHoverEnter);
        socket.hoverExited.AddListener(OnHoverExit);
        socket.selectEntered.AddListener(OnSelectEnter);
        socket.selectExited.AddListener(OnSelectExit);
    }

    private void OnSelectEnter(SelectEnterEventArgs args)
    {


        //Debug.Log($"Object {args.interactableObject.transform.name} SNAPPED into socket");

      
        // // Check if this SocketInteractor has a Card Snap Point Finds child with exact name "Card__SnapPoint"
        // cardSnapPoint = transform.Find("Card_SnapPointA")?.gameObject;  // if it does or else retur Null. The ? is a Elvis operator

        // if (cardSnapPoint != null)
        // {
        //     //Get Reference to the Card that was dropped.....
        //     theNetworkCard = args.interactableObject.transform.gameObject;

        //     //Check if that Card has a Child GameObject named __SocketPlacement. This hold the exact placement info
        //     CardSoketPlacementValue = theNetworkCard.transform.Find("__SocketPlacement")?.gameObject;
        //     if (CardSoketPlacementValue != null)
        //     {       // if so copy that Data to the CardSnapPoint, so card can be places perfectly in slot
        //         cardSnapPoint.transform.localPosition = CardSoketPlacementValue.transform.localPosition;
        //         cardSnapPoint.transform.localRotation = CardSoketPlacementValue.transform.localRotation;
        //         cardSnapPoint.transform.localScale = CardSoketPlacementValue.transform.localScale;
        //     }
        //     else
        //        Debug.LogWarning("__SocketPlacement not found as direct child!");         
        // }
        // else
        //      Debug.LogWarning("__SocketPlacement not found as direct child!");  

        

       
    
    }

    private void OnSelectExit(SelectExitEventArgs args)
    {
        //Debug.Log($"Object {args.interactableObject.transform.name} UNSNAPPED from socket");
    }



    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        // SANMI USE IN FUTURE FOR VISUALS
        Debug.Log($"Object {args.interactableObject.transform.name} entered socket range in HoverEntered");


      
                    // Check if this SocketInteractor has a Card Snap Point Finds child with exact name "Card__SnapPoint"
                    cardSnapPoint = transform.Find("Card_SnapPointB")?.gameObject;  // if it does or else retur Null. The ? is a Elvis operator

                    if (cardSnapPoint != null)
                    {
                        //Get Reference to the Card that was dropped.....
                        theNetworkCard = args.interactableObject.transform.gameObject;

                        //Check if that Card has a Child GameObject named __SocketPlacement. This hold the exact placement info
                        CardSoketPlacementValue = theNetworkCard.transform.Find("__Card_Socket_Placement_Position")?.gameObject;
                        if (CardSoketPlacementValue != null)
                        {       // if so copy that Data to the CardSnapPoint, so card can be places perfectly in slot
                            cardSnapPoint.transform.localPosition = CardSoketPlacementValue.transform.localPosition;
                            cardSnapPoint.transform.localRotation = CardSoketPlacementValue.transform.localRotation;
                            cardSnapPoint.transform.localScale = CardSoketPlacementValue.transform.localScale;
                        }
                        else
                        Debug.LogWarning("__SocketPlacement not found as direct child!");         
                    }
                    else
                        Debug.LogWarning("__SocketPlacement not found as direct child!"); 

    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        //Debug.Log($"Object {args.interactableObject.transform.name} left socket range");
    }

}