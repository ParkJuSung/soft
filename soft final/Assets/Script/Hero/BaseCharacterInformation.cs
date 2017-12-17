using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterInformation {
	[SerializeField] private int HP;
	[SerializeField] private int moveSpeed;
	[SerializeField] private Vector3 position;
	[SerializeField] private int damage;
	[SerializeField] public Animator anim;
	/*public Animator Anim
	{
		get{
			return anim;
		}
		set { }
	}*/
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Attack(Vector3 targetPosition)
	{

	}

	public bool IsDie()
	{
		if (HP <= 0)
			return true;

		return false;
	}

	public int GetHP()
	{
		return HP;
	}

	public void SetHP(int hp)
	{
		HP = hp;
	}

	public void SubtractionHP(int hp)
	{
		HP = HP - hp;
	}
	public void SetMoveSpeed(int moveSpeed)
	{
		this.moveSpeed = moveSpeed;
	}

	public int GetMoveSpeed()
	{
		return moveSpeed;
	}
	public void SetPostion(Vector3 position)
	{
		this.position = position;
	}

	public void SetDamage(int damage)
	{
		this.damage = damage;
	}

	public int GetDamae()
	{
		return damage;
	}


	public Vector3 GetPostion()
	{
		return position;
	}

}
