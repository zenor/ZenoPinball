using UnityEngine;
using System.Collections;

public class Plunger : MonoBehaviour {

	const float MAX_DISTANCE = 1f;
	const float PULL_SPEED = 0.5f;
	const float RESET_SPEED = 10f;

	public GameObject ball;
	public float maxForce = 2200;

	bool _resetting;
	bool _active;
	Vector3 _startPos;
	Vector3 _ballStartPos;


	// Use this for initialization
	void Start () {
		_active = true;
		_startPos = gameObject.transform.position;
		_ballStartPos = ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!_resetting && _active
		    && Input.GetKey(KeyCode.Space) 
		    && Mathf.Abs(gameObject.transform.position.z - _startPos.z) < 1f)
		{
			_resetting = false;
			Vector3 moveAmount = new Vector3(0f, 0f, -PULL_SPEED * Time.deltaTime);
			gameObject.transform.Translate(moveAmount);
			ball.transform.Translate(moveAmount);
		}

		if (_active && Input.GetKeyUp(KeyCode.Space))
		{
			float distance = Mathf.Abs(gameObject.transform.position.z - _startPos.z);
			ball.rigidbody.AddForce(0f, 0f, maxForce * distance);
			_resetting = true;
			_active = false;
		}

		if (_resetting)
		{
			if (gameObject.transform.position.z < _startPos.z)
			{
				Vector3 moveAmount = new Vector3(0f, 0f, RESET_SPEED * Time.deltaTime);
				gameObject.transform.Translate(moveAmount);
			}
			else
				_resetting = false;
		}
	}

	public void Reload() {
		ball.rigidbody.velocity = Vector3.zero;
		ball.rigidbody.angularVelocity = Vector3.zero;
		ball.transform.localRotation = Quaternion.identity;
		ball.transform.position = _ballStartPos;
		_active = true;
	}

	public bool active {
		set {_active = value;}
	}
}
