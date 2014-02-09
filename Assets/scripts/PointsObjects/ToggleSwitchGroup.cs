using UnityEngine;
using System.Collections.Generic;

public class ToggleSwitchGroup : PointsGiver {

	List<ToggleSwitch> _switches = new List<ToggleSwitch>();
	List<bool> _currStates = new List<bool>();

	// Use this for initialization
	void Start () {
		base.Start();
		foreach(ToggleSwitch ts in gameObject.GetComponentsInChildren<ToggleSwitch>()) {
			_switches.Add(ts);
			_currStates.Add(ts.active);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.LeftShift)
		    || Input.GetKeyDown(KeyCode.RightShift)) {
			CycleToggleSwitches();
		}
	}

	void CycleToggleSwitches() {


		for (int i = 0; i < _switches.Count; ++i) {
			if (i == 0)
				_switches[i].active = _currStates[_switches.Count - 1];
			else
				_switches[i].active = _currStates[i - 1];
		}

		UpdateStates();
	}

	public void UpdateStates() {
		bool isComplete = true;
		for (int i = 0; i < _switches.Count; ++i) {
			_currStates[i] = _switches[i].active;
			if (!_currStates[i])
				isComplete = false;
		}
		if (isComplete) {
			AddPoints();
			for (int i = 0; i < _switches.Count; ++i) {
				_switches[i].active = false;
				_currStates[i] = false;
			}
		}
	}
}
