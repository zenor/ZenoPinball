using UnityEngine;
using System.Collections;

public abstract class PointsGiver : MonoBehaviour {

	public int points = 10;
	public string message = "";

	GameManager _gameManager;

	// Use this for initialization
	protected void Start () {
		_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected void AddPoints() {
		_gameManager.AddPoints(points);
		_gameManager.Message(message);
	}
}
