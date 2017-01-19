using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour {

	public float thrust=5;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.localRotation = new Quaternion ();
	}

	void FixedUpdate() 
	{
		rb.AddForce(new Vector3(1f,0f) * thrust);

	}
}
