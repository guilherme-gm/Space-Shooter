using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {
	public float Tumble;

	private Rigidbody RB;

	void Start()
	{
		RB = this.GetComponent<Rigidbody> ();

		RB.angularVelocity = Random.insideUnitSphere * Tumble;
	}
}
