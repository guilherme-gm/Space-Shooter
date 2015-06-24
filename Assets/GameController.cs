using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject Hazard;
	public Vector3 SpawnValues;

	void Start ()
	{
		SpawnWaves ();
	}

	void SpawnWaves()
	{
		Vector3 spawnPosition = new Vector3 (Random.Range(-SpawnValues.x, SpawnValues.x), SpawnValues.y, SpawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;

		Instantiate (Hazard, spawnPosition, spawnRotation);
	}
}
