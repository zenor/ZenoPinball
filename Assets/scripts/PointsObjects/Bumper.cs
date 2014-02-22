using UnityEngine;
using System.Collections;

public class Bumper : PointsGiver {

	public float scaleTo = 1.2f;
	public float cameraShake = 0.008f;
	public float kickerForce = 100f;

	CameraTricks _camera;

	Transform _meshTransform;
	bool _scaling;
	float _scaleRate = 0.05f;

	// Use this for initialization
	void Start () {
		base.Start();
		_meshTransform = gameObject.transform.GetChild(0);
		_camera = GameObject.Find("Main Camera").GetComponent<CameraTricks>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (_scaling)
		{
			if (_meshTransform.localScale.x < 1f)
				_scaleRate = Mathf.Abs(_scaleRate);
			else if (_meshTransform.localScale.x > scaleTo)
				_scaleRate = -Mathf.Abs(_scaleRate);

			_meshTransform.localScale += Vector3.one * _scaleRate;

			if (_meshTransform.localScale.x < 1f)
				_scaling = false;
		}
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.transform.tag == "Ball") {
			AddPoints();
			_camera.Shake(cameraShake);
			_scaling = true;
		}
	}

	void OnCollisionExit (Collision collision) {
		if (collision.transform.tag == "Ball") {
			if (collision.rigidbody.velocity.magnitude < Constants.Ball.MaxVelocity) {
				Debug.Log("ball velocity: " + collision.rigidbody.velocity.magnitude);
				float x = collision.rigidbody.velocity.x > 0 ? kickerForce : -kickerForce;
				float z = collision.rigidbody.velocity.z > 0 ? kickerForce : -kickerForce;
				collision.rigidbody.AddForce(new Vector3(x, 0f, z));
			}
		}
	}
}
