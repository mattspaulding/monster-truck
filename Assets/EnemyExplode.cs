using Exploder2D;
using UnityEngine;

public class EnemyExplode : MonoBehaviour {


	public GameObject Enemy = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		if (GUI.Button (new Rect (30, 30, 100, 30), "Explode Enemy")) {

			var exploder = Exploder2D.Utils.Exploder2DSingleton.Exploder2DInstance;

			if (exploder && Enemy) {

				exploder.Radius = 1.0f;
				exploder.TargetFragments = 100;
			//	exploder.transform.position = Exploder2DUtils.GetCentroid (Enemy);

				exploder.Explode ();
			}
		}
	}
}
