using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour {

	public int points = 10;

	GameManager _gameManager;

	// Use this for initialization
	void Start () {

		_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision collision) {

		_gameManager.AddPoints(points);
	}
}
