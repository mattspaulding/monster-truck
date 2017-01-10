using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float space = Input.GetAxis("Jump"); //break control input
		if (space>0) {
			Application.LoadLevel ("Game/CharacterSelect");
		}
		
	}
}
