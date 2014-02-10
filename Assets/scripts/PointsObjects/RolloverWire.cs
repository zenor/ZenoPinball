using UnityEngine;
using System.Collections;

public class RolloverWire : PointsGiver {

	// Use this for initialization
	void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Ball")
			AddPoints();
	}
}
