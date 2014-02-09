using UnityEngine;
using System.Collections;

public class ToggleSwitch : PointsGiver {

	public float inactiveOffset = 0.07f;

	ToggleSwitchGroup _group;
	bool _active = false;
	Vector3 _offPos;
	Vector3 _onPos;

	// Use this for initialization
	void Start () {
		base.Start();
		_onPos = gameObject.transform.position;
		_offPos = _onPos;
		_offPos.y -= inactiveOffset;
		gameObject.transform.position = _offPos;
		_group = gameObject.transform.parent.GetComponent<ToggleSwitchGroup>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Toggle() {
		_active = !_active;
		_group.UpdateStates();
		setPos();
	}

	public bool active {
		get { return _active; }
		set {
			_active = value;
			setPos();
		}
	}

	void setPos() {
		if (_active)
			gameObject.transform.position = _onPos;
		else
			gameObject.transform.position = _offPos;
	}

	void OnTriggerEnter(Collider collider) {
		AddPoints();
		Toggle();
	}
}
