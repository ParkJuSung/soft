using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager{

	private static UIManager instance = null;
	public static UIManager Instance
	{
		get
		{
			if (instance == null)
				instance = new UIManager();

			return instance;
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void DrawBar(Slider ber, GameObject HeadUpPosition,int barValue ,int MAX)
	{
		ber.value = (float)barValue / MAX;
		ber.transform.position = HeadUpPosition.transform.position;
	}

	/*public static UIManager Getinstance()
	{
		if (instance == null)
			instance = new UIManager();

		return instance;
	}*/
}
