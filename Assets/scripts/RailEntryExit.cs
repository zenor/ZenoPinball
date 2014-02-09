using UnityEngine;
using System.Collections;

public class RailEntryExit : MonoBehaviour {

	public GameObject playfieldTopCollider;
	Collider _collider;

	// Use this for initialization
	void Start () {
		_collider = playfieldTopCollider.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		_collider.enabled = !_collider.enabled;
	}
}
