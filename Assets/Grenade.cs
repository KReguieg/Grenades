using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

    [SerializeField]
    private float delay = 3.0f;

    private float countdown;

    [SerializeField]
    private GameObject explosionEffect;

    [SerializeField]
    private float blastRadius = 5.0f;

    [SerializeField]
    private float explosionForce = 700.0f;

    bool exploded = false;

    // Use this for initialization
    private void Start () {
        countdown = delay;
	}
	
	// Update is called once per frame
	private void Update () {
        countdown -= Time.deltaTime;
        if(countdown <= 0.0f && !exploded)
        {
            Explode();
            exploded = true;
        }
	}

    private void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] nearbyObjectsToDestory = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (var nearbyObjects in nearbyObjectsToDestory)
        {
            Destructible dest = nearbyObjects.GetComponent<Destructible>();
            if (dest != null)
                dest.DestroyObject();
        }

        Collider[] nearbyObjectsToMove = Physics.OverlapSphere(transform.position, blastRadius);

        foreach (var nearbyObject in nearbyObjectsToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, blastRadius);
            }
        }

        Destroy(gameObject);
    }
}
