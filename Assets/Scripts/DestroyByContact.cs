using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject Explosion;
	public GameObject PlayerExplosion;
	public int ScoreValue;

	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}

		if (gameController == null)
			Debug.Log ("Cannot find 'GameController' script.");
	}

	void OnTriggerEnter(Collider other) {

		if (other.CompareTag ("Boundary")) {
			return;
		}

		Instantiate (Explosion, transform.position, transform.rotation);
		if (other.CompareTag ("Player")) {
			Instantiate (PlayerExplosion, other.transform.position, other.transform.rotation);
		}

		gameController.AddScore(ScoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);

	}
}
