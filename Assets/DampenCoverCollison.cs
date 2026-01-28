using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class DampenCoverCollison : MonoBehaviour
{

    private XRBaseInteractable interactable; // Reference to this object's interactable

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }




    // Add this to your Case A script
    void OnCollisionEnter(Collision collision)
    {
        print("In Collision");
        if (collision.gameObject.CompareTag("SideCover"))
        {

            // Get rigidbody from the object or its parents
            Rigidbody rb = collision.gameObject.GetComponentInParent<Rigidbody>();

            if (rb != null)
            {
                // Works even if the specific collider is on a child object
                Debug.Log($"Found parent Rigidbody: {rb.gameObject.name}");
                // Stop all movement
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                // Reset forces for next physics update
                rb.ResetCenterOfMass();
                rb.ResetInertiaTensor();
                // Move backward by 1cm (0.01 units) along collision normal
                Vector3 collisionNormal = collision.contacts[0].normal;
                Vector3 backDirection = -collisionNormal.normalized;
                //rb.transform.position += backDirection * 0.1f;
            }

            Debug.Log("cover collides");
            //StartCoroutine(Stabilize());

            rb = GetComponent<Rigidbody>();

            // Stop all movement
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Cancel any forces in the next physics update
            rb.ResetCenterOfMass();
            rb.ResetInertiaTensor();

            // Freeze all motion
            //rb.constraints = RigidbodyConstraints.FreezeAll;

            // Optional: Also stop any coroutines or custom physics
            StopAllCoroutines();
            Debug.Log("NeutralizeAllForces");


        }
    }


}
