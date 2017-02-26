using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour {

	public bool isReadyToSelect = true;
	public int characterIndex = 0;

	private float prevSpace=1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		#region UserInput
		float vertical = Input.GetAxis("Vertical"); //Forward & Backward drive input
		float horizontal = Input.GetAxis("Horizontal"); //Angular velocity control input
		float space = Input.GetAxis("Jump"); //break control input
		#endregion

		if (isReadyToSelect) {
			if (horizontal > 0 && characterIndex<1) {
				characterIndex++;
				isReadyToSelect = false;
			}
			if (horizontal < 0 &&characterIndex>0) {
				characterIndex--;
				isReadyToSelect = false;
			}
		}

				if (horizontal == 0) {
			isReadyToSelect = true;
		}

		if (space > 0 && prevSpace==0) {
			GlobalControl.Instance.CharacterIndex = characterIndex;
			Application.LoadLevel ("Game/World1");
		}
		prevSpace = space;

		Camera.main.transform.position = Vector3.Lerp(
			Camera.main.transform.position, 
			new Vector3(characterIndex*20, Camera.main.transform.position.y, -10), 
			Time.deltaTime * 5);
	}
}
