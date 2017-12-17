using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DrawBar : MonoBehaviour {
	[SerializeField] private List<Slider> HPber = new List<Slider>();
	[SerializeField] private List<GameObject> HeadUpPosition = new List<GameObject>();
	[SerializeField] private List<HeroCharacter> herocharacter = new List<HeroCharacter>();
	private int heroMaxHp = 100;
	private int monsterMaxHp = 10;

	[SerializeField] private List<MinionMonster> minion = new List<MinionMonster>();
	[SerializeField] private List<Slider> MonsterHPber = new List<Slider>();
	[SerializeField] private List<GameObject> MHeadUpPosition = new List<GameObject>();

	// Use this for initialization
	void Start () {
		herocharacter.Add(GameObject.Find("Soldier").GetComponent<HeroCharacter>());
		HPber.Add(GameObject.Find("Progress Bar Hp").GetComponent<Slider>());
		HeadUpPosition.Add(GameObject.Find("Soldier/HeadUpPosition"));

		minion.Add(GameObject.Find("Monster").GetComponent<MinionMonster>());
		MonsterHPber.Add(GameObject.Find("MonsterHpBar").GetComponent<Slider>());
		MHeadUpPosition.Add(GameObject.Find("MHeadUpPosition"));
	}

	// Update is called once per frame
	void Update() {
		if (herocharacter != null)
		{
			for (int i = 0; i < HPber.Count; i++)
			{
				UIManager.Instance.DrawBar(HPber[i], HeadUpPosition[i],
						 herocharacter[i].heroinfo.baseCharacterInformation.GetHP(), heroMaxHp);
			}
		}

		if (minion != null)
		{
			for (int i = 0; i < MonsterHPber.Count; i++)
			{
				UIManager.Instance.DrawBar(MonsterHPber[i], MHeadUpPosition[i],
				minion[i].miniMonster.basecharacterinformation.GetHP(), monsterMaxHp);
			}
		}

		if(Input.GetKeyDown(KeyCode.Space))
		{
			/*MHeadUpPosition.Add(Instantiate(Resources.Load("Prefab/MHeadUpPosition", typeof(Slider)),
								new Vector3(UnitManager.Instance.minion[minion.Count].miniMonster.basecharacterinformation.GetPostion().x,
								UnitManager.Instance.minion[minion.Count].miniMonster.basecharacterinformation.GetPostion().y + 0.8f,
								UnitManager.Instance.minion[minion.Count].miniMonster.basecharacterinformation.GetPostion().z), Quaternion.identity) 
								as GameObject);
			MonsterHPber.Add(Instantiate(Resources.Load("MonsterHpBar", typeof(Slider)), 
							MHeadUpPosition[MHeadUpPosition.Count].transform.position,Quaternion.identity) as Slider) ;*/
			
		}


	}

	public Slider GetMonsterHPber(int index)
	{
		return MonsterHPber[index];
	}

	public List<Slider> GetSliderMListHPber()
	{
		return MonsterHPber;
	}

	public List<Slider> GetSliderHListHPber()
	{
		return HPber;
	}
	public GameObject GetMHeadUpPosition(int index)
	{
		return MHeadUpPosition[index];
	}

	public GameObject GetHeroHPber(int index)
	{
		return HPber[index].gameObject;
	}

	public GameObject GetHHeadUpPosition(int index)
	{
		return HeadUpPosition[index].gameObject;
	}

	public void RemoveMonsterList(int index)
	{
		minion.RemoveAt(index);
		MonsterHPber.RemoveAt(index);
		MHeadUpPosition.RemoveAt(index);
	}

	public void RemoveHeroList(int index)
	{
		herocharacter.RemoveAt(index);
		HPber.RemoveAt(index);
		HeadUpPosition.RemoveAt(index);
	}


}
