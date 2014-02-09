using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

	public float closedMoveAmount = 0.1f;
	Vector3 _openPos;
	Vector3 _closedPos;


	// Use this for initialization
	void Start () {
		_openPos = gameObject.transform.position;
		_closedPos = new Vector3(_openPos.x - closedMoveAmount, _openPos.y, _openPos.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider collider) {
		if (collider.transform.position.z > gameObject.transform.position.z)
			Close();
	}

	void Close() {
		gameObject.transform.position = _closedPos;
	}

	public void Open() {
		gameObject.transform.position = _openPos;
	}
}
