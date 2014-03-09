using UnityEngine;
using System.Collections;

public class BreakOutBlock : PointsGiver {

	// Use this for initialization
	void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.transform.tag == "Ball") {
			AddPoints();
			gameObject.SetActive(false);
		}
	}
}
