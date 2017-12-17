using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoserManager : MonoBehaviour {
	public GameObject monster;
	public static bool isInScene;
	// Use this for initialization
	void Start () {
		isInScene = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Instantiate(monster, new Vector3(0, 0, 0), Quaternion.identity);
			isInScene = true;
		}
	}
}
