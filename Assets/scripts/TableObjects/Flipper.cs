using UnityEngine;
using System.Collections;

public class Flipper : MonoBehaviour {

	public enum Side {left, right};
	public Side side;	
	public float speed = 100f;
	public HingeJoint hingeJoint;

	float _maxAngle = 60f;
	JointSpring spring = new JointSpring();

	float _targetAngle;

	void Awake () {
		hingeJoint.useSpring = true;
	}

	void Start() {
		spring.spring = speed;
		spring.damper = 1f;

		HingeJoint hinge = gameObject.GetComponent<HingeJoint> ();
		_maxAngle = hinge.limits.max;

		// rotation direction is set by the hinge axis.
		// just in case designer forgets to set the axis, do it here
		if (side == Side.left)
			hinge.axis = Vector3.down;
		else
			hinge.axis = Vector3.up;
	}
	
	// Update is called once per frame
	void Update () {


	}

	void FixedUpdate() {
		if ((side == Side.right && Input.GetKey(KeyCode.RightShift))
		    || (side == Side.left && Input.GetKey(KeyCode.LeftShift)))
			spring.targetPosition = _maxAngle;
		else
			spring.targetPosition = 0f;
		
		hingeJoint.spring = spring;
	}
}
