using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xxxRemoveAllPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
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
}
