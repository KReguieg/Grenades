using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour {

    [SerializeField]
    private float throwForce = 400.0f;

    [SerializeField]
    private GameObject grenadePrefab;
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            ThrowGrenade();
        }
	}

    private void ThrowGrenade()
    {
        Debug.Log("FIRE IN THE HOLE!");
        // Create Grenade
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        if(rb != null)
        {
            // Throw it
            rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
        }
    }
}
