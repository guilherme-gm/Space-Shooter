﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public float fireRate;
	public float nextFire;

	public Boundary boundary;

	public GameObject Shot;
	public Transform ShotSpawn;

	private AudioSource Audio;
	Rigidbody RB;

	void Start()
	{
		RB = this.GetComponent<Rigidbody> ();
		Audio = this.GetComponent<AudioSource> ();
	}

	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (Shot, ShotSpawn.position, ShotSpawn.rotation);
			Audio.Play ();
		}
		//Input.GetButton("Fire1")
		//
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		RB.velocity = movement  * speed;

		RB.position = new Vector3
		(
			Mathf.Clamp(RB.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(RB.position.z, boundary.zMin, boundary.zMax)
		);

		RB.rotation = Quaternion.Euler (0.0f, 0.0f, RB.velocity.x * -tilt);
	}
}
