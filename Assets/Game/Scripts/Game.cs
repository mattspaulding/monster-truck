﻿using UnityEngine;
using System.Collections;
using System;

public class Game : MonoBehaviour
{

	//    public GameObject[] Vehicles;

	private GameObject _currentVehicle;

	private bool _showInfo = true;

	public float startTimer = 5;
	public float finishTimer = 5;

	[HideInInspector]
	public bool finish = false;
	[HideInInspector]
	public string nextLevel;


	void Start ()
	{

		var characterIndex = GlobalControl.Instance.CharacterIndex;
		switch (characterIndex) {
		case 0:
			_currentVehicle = GameObject.Instantiate ((GameObject)Resources.Load ("Truck"));
			break;
		case 1:
			_currentVehicle = GameObject.Instantiate ((GameObject)Resources.Load ("Motorbike"));
			break;
		default:
			_currentVehicle = GameObject.Instantiate ((GameObject)Resources.Load ("Truck"));
			break;


		}
	}

	
	void FixedUpdate ()
	{
		if (_currentVehicle != null) {
			Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, new Vector3 (_currentVehicle.transform.position.x, _currentVehicle.transform.position.y, -10), Time.deltaTime * 15);
		}
		if (startTimer > 0) {
			startTimer -= Time.deltaTime;
		} else {
			GameObject.FindWithTag ("Player").GetComponent<CarController2D> ().enabled = true;
			Time.timeScale = 2f;
		}

		if (finish) {
			GameObject.FindWithTag ("Player").GetComponent<CarController2D> ().enabled = false;
			Time.timeScale = 0.5f;
			if (finishTimer > 0) {
				finishTimer -= Time.deltaTime;
			} else {
				Application.LoadLevel ("Game/" + nextLevel);
				Time.timeScale = 1f;
			}
		}

	}

	void OnGUI ()
	{
		GUILayout.BeginHorizontal ();
//        if (GUILayout.Button("Motorbike"))
//        {
//            SetControls(0);
//        }
//        if (GUILayout.Button("Bigfoot"))
//        {
//            SetControls(1);
//        }
//        if (GUILayout.Button("Tractor"))
//        {
//            SetControls(2);
//        }
		GUILayout.Label ("[W/S] - Move forward/backward; [A/D] - Angular control; [Space] - Break; [control] - turn; [shift] - nitro");
        
		GUILayout.EndHorizontal ();
		_showInfo = GUILayout.Toggle (_showInfo, "Info");
		if (_currentVehicle != null && _showInfo) {
			GUILayout.Label ("Drive type: " + _currentVehicle.GetComponent<CarController2D> ().DriveType.ToString ());
			GUILayout.Label ("Acceleration: " + _currentVehicle.GetComponent<CarController2D> ().Acceleration.ToString ());
			GUILayout.Label ("Max. speed: " + _currentVehicle.GetComponent<CarController2D> ().MaxSpeed.ToString ());
			GUILayout.Label ("Braking force: " + _currentVehicle.GetComponent<CarController2D> ().BrakingForce.ToString ());
			GUILayout.Label ("Grounded: " + _currentVehicle.GetComponent<CarController2D> ().IsGrounded.ToString ());
			GUILayout.Label ("Front Wheel Grounded: " + _currentVehicle.GetComponent<CarController2D> ().FrontWheel.IsGrounded.ToString ());
			GUILayout.Label ("Back Wheel Grounded: " + _currentVehicle.GetComponent<CarController2D> ().BackWheel.IsGrounded.ToString ());
		}

		var fontStyle = new GUIStyle ();
		fontStyle.fontSize = 40;
		fontStyle.normal.textColor = Color.white;
		if (startTimer > 0) {
			GUI.Label (new Rect (370, 120, 100, 20), Math.Ceiling (startTimer).ToString (), fontStyle);
		}

	}

	//    void SetControls(int id)
	//    {
	//        for (int i = 0; i < Vehicles.Length; i++)
	//        {
	//            if (i == id)
	//            {
	//                Vehicles[i].GetComponent<CarController2D>().Enabled = true;
	//                _currentVehicle = Vehicles[i];
	//            }
	//            else Vehicles[i].GetComponent<CarController2D>().Enabled = false;
	//        }
	//    }

    
}
