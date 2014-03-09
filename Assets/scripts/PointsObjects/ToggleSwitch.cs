using UnityEngine;
using System.Collections;

public class ToggleSwitch : PointsGiver, IResetable {

	public float inactiveOffset = 0.07f;
	
	public Material offMaterial;

	MeshRenderer _meshRenderer;
	Material _onMaterial;
	ToggleSwitchGroup _group;
	bool _active = false;
	Vector3 _offPos;
	Vector3 _onPos;

	// Use this for initialization
	void Start () {
		base.Start();
		_meshRenderer = gameObject.GetComponent<MeshRenderer>();
		_onPos = gameObject.transform.position;
		_offPos = _onPos;
		_offPos.y -= inactiveOffset;
		_onMaterial = _meshRenderer.materials[0];

		if (offMaterial) {
			_meshRenderer.material = offMaterial;
		}
		gameObject.transform.position = _offPos;
		_group = gameObject.transform.parent.GetComponent<ToggleSwitchGroup>();

		// Register with GM for resetting
		GameObject.Find("GameManager").GetComponent<GameManager>().AddResetableObject(this, GameManager.ResetableType.GameOver);
	}
	
	public void Reset() {
		this.active = false;
	}

	public void Toggle() {
		_active = !_active;
		_group.UpdateStates();
		setPos();
		setMat ();
	}

	public bool active {
		get { return _active; }
		set {
			_active = value;
			setPos();
			setMat();
		}
	}

	void setPos() {
		if (_active)
			gameObject.transform.position = _onPos;
		else
			gameObject.transform.position = _offPos;
	}

	void setMat() {
		if (offMaterial) {
			_meshRenderer.material = _active ? _onMaterial : offMaterial;
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Ball") {
			AddPoints();
			Toggle();
		}
	}
}
