using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour{
	[SerializeField]  public List<HeroCharacter> herocharacter { get; set; }
	[SerializeField]  public List<MinionMonster> minion { get; set; }

	private static UnitManager instance = null;
	public static UnitManager Instance
	{
		get
		{
			if (instance == null)
				instance = new UnitManager();

			return instance;
		}
	}

	// Use this for initialization
	void Start () {
		herocharacter = new List<HeroCharacter>();
		minion = new List<MinionMonster>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Instantiate(Resources.Load("Prefab/Monster"), new Vector3(0, 0, 0), Quaternion.identity);
			minion.Add(GetComponent<MinionMonster>());
		}
	}
}
