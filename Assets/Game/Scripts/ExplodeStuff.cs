using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeStuff : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Exploder2D")
		{
			var exploder = Exploder2D.Utils.Exploder2DSingleton.Exploder2DInstance;

			exploder.transform.position = Exploder2D.Exploder2DUtils.GetCentroid(col.gameObject);
			exploder.Radius = 1.0f;
			exploder.Explode();
		}
	}
}
