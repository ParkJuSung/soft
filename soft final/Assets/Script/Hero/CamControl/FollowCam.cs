using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

	[SerializeField]  private Transform targetTr;
	[SerializeField]  private float dist;
	[SerializeField]  private float height;
	[SerializeField]  private float dampTrace;
	[SerializeField]  private Transform tr;
	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform>();
		dist = 3f;
		height = 3f;
		dampTrace = 20.0f;
		targetTr = GameObject.Find("Soldier").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate()
	{
		if (targetTr != null)
		{
			tr.position = Vector3.Lerp(tr.position, targetTr.position -
				(targetTr.forward * dist) + (Vector3.up * height), Time.deltaTime * dampTrace);

			tr.LookAt(targetTr.position);
		}
	}
}
