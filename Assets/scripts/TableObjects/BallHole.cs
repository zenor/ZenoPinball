using UnityEngine;
using System.Collections;

public class BallHole : MonoBehaviour {

	GameManager _gameManager;

	// Use this for initialization
	void Start () {
		_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.tag == "Ball") {
			_gameManager.BallOver();
		}
	}
}
