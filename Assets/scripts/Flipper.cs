using UnityEngine;
using System.Collections;

public class Flipper : MonoBehaviour {

	public bool right;

	public float maxAngle = 60f;
	public float speed = 100f;

	public HingeJoint hingeJoint;

	private JointSpring spring = new JointSpring();

	float _targetAngle;

	void Awake () {
		hingeJoint.useSpring = true;
	}

	void Start() {
		spring.spring = speed;
		spring.damper = 1f;

		if (!right)
			maxAngle = -maxAngle;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.RightShift))
			spring.targetPosition = maxAngle;
		else
			spring.targetPosition = 0f;

		hingeJoint.spring = spring;
	}

	void FixedUpdate() {

	}
}
