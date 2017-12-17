using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DrawBar : MonoBehaviour {

	[SerializeField] private Slider HPber;
	[SerializeField] private GameObject HeadUpPosition;
	[SerializeField] private HeroCharacter herocharacter;
	private int heroMaxHp = 100;
	private int monsterMaxHp = 10;

	[SerializeField] private MinionMonster minion;
	[SerializeField] private Slider MonsterHPber;
	[SerializeField] private GameObject MHeadUpPosition;

	// Use this for initialization
	void Start () {
		herocharacter = GameObject.Find("Soldier").GetComponent<HeroCharacter>();
		HPber = GameObject.Find("Progress Bar Hp").GetComponent<Slider>();
		HeadUpPosition = GameObject.Find("Soldier/HeadUpPosition");

		minion = GameObject.Find("Monster").GetComponent<MinionMonster>();
		MonsterHPber = GameObject.Find("MonsterHpBar").GetComponent<Slider>();
		MHeadUpPosition = GameObject.Find("MHeadUpPosition");
	}

	// Update is called once per frame
	void Update() {
		if (herocharacter != null)
		{
			UIManager.Instance.DrawBar(HPber, HeadUpPosition,
					 herocharacter.heroinfo.baseCharacterInformation.GetHP(), heroMaxHp);
		}

		if (minion != null)
		{
			UIManager.Instance.DrawBar(MonsterHPber, MHeadUpPosition,
			minion.miniMonster.basecharacterinformation.GetHP(), monsterMaxHp);
		}
	}

	public GameObject GetMonsterHPber()
	{
		return MonsterHPber.gameObject;
	}

	public GameObject GetMHeadUpPosition()
	{
		return MHeadUpPosition;
	}

	public GameObject GetHeroHPber()
	{
		return HPber.gameObject;
	}

	public GameObject GetHHeadUpPosition()
	{
		return HeadUpPosition.gameObject;
	}
}
