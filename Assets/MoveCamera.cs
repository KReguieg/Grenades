using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
            transform.position += Vector3.left;
        if (Input.GetKeyDown(KeyCode.W))
            transform.position += Vector3.up;
        if (Input.GetKeyDown(KeyCode.S))
            transform.position += Vector3.back;
        if (Input.GetKeyDown(KeyCode.D))
            transform.position += Vector3.right;
    }
}
