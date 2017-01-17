using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {


		#region UserInput
		float vertical = Input.GetAxis("Vertical"); //Forward & Backward drive input
		float horizontal = Input.GetAxis("Horizontal"); //Angular velocity control input
		float space = Input.GetAxis("Jump"); //break control input
		float cancel = Input.GetAxis("Cancel");
		#endregion

		if (cancel > 0) {
			Application.LoadLevel ("Game/Title");
		}
			
	}
}
