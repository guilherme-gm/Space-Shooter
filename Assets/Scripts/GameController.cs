﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject Hazard;
	public Vector3 SpawnValues;
	public int HazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);

		while(true)
		{
			for (int i = 0; i < HazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-SpawnValues.x, SpawnValues.x), SpawnValues.y, SpawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;

				Instantiate (Hazard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds(spawnWait);
			}

			yield return new WaitForSeconds(waveWait);
		}
	}
}
