using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour {

	public int points = 10;
	public float scaleTo = 1.2f;

	GameManager _gameManager;
	Transform _meshTransform;
	bool _scaling;
	float _scaleRate = 0.05f;

	// Use this for initialization
	void Start () {

		_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		_meshTransform = gameObject.transform.GetChild(0);
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

		_gameManager.AddPoints(points);
		_scaling = true;
		//_meshTransform.localScale = new Vector3(scaleTo, 1f, scaleTo);
	}
}
