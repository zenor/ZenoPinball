using UnityEngine;
using System.Collections;

public class Table : MonoBehaviour {

	// public only to be set in the Inspector
	public float _angle = 8;

	// Use this for initialization
	void Start () {
	
		gameObject.transform.Rotate(new Vector3(-_angle, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
