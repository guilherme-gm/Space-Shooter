using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject Explosion;
	public GameObject PlayerExplosion;

	void OnTriggerEnter(Collider other) {

		if (other.CompareTag ("Boundary")) {
			return;
		}

		Instantiate (Explosion, transform.position, transform.rotation);
		if (other.CompareTag ("Player")) {
			Instantiate (PlayerExplosion, other.transform.position, other.transform.rotation);
		}

		Destroy (other.gameObject);
		Destroy (gameObject);

	}
}
