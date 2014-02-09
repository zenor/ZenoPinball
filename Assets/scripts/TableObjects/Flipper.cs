using UnityEngine;
using System.Collections;

public class Flipper : MonoBehaviour {

	public enum Side {left, right};
	public Side side;

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

		if (side == Side.left)
			maxAngle = -maxAngle;
	}
	
	// Update is called once per frame
	void Update () {

		if ((side == Side.right && Input.GetKey(KeyCode.RightShift))
		    || (side == Side.left && Input.GetKey(KeyCode.LeftShift)))
			spring.targetPosition = maxAngle;
		else
			spring.targetPosition = 0f;

		hingeJoint.spring = spring;
	}

	void FixedUpdate() {

	}
}
