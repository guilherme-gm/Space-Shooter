using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float Speed;
	public float tilt;
	public Boundary boundary;

	Rigidbody RB;

	void Start() {
		RB = this.GetComponent<Rigidbody> ();

	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		RB.velocity = movement  * Speed;

		RB.position = new Vector3
		(
			Mathf.Clamp(RB.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(RB.position.z, boundary.zMin, boundary.zMax)
		);

		RB.rotation = Quaternion.Euler (0.0f, 0.0f, RB.velocity.x * -tilt);
	}
}
