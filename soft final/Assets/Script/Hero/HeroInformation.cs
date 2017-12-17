using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInformation{

	public enum JumpState
	{
		OneJump,TwoJump,SuperJump,UnJump
	}

	[SerializeField]  private int jumpSpeed;
	[SerializeField]  private int[] skills = new int[2];
	[SerializeField]  private bool[] isSkillsCoolTime = new bool[2];
	[SerializeField]  private int Exp;
	[SerializeField]  private int Range;
	[SerializeField]  private int Level;
	[SerializeField] public Rigidbody rigidbody;
	public BaseCharacterInformation baseCharacterInformation;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Move(Transform t)
	{
		if (Input.GetKey(KeyCode.A))
		{
			t.Translate(Vector3.left * baseCharacterInformation.GetMoveSpeed() * Time.deltaTime);
			baseCharacterInformation.anim.SetBool("IsRun", true);

		}
		if (Input.GetKey(KeyCode.D))
		{
			t.Translate(Vector3.right * baseCharacterInformation.GetMoveSpeed() * Time.deltaTime);
			baseCharacterInformation.anim.SetBool("IsRun", true);
		}
		if (Input.GetKey(KeyCode.W))
		{
			t.Translate(Vector3.forward * baseCharacterInformation.GetMoveSpeed() * Time.deltaTime);
			baseCharacterInformation.anim.SetBool("IsRun", true);
		}
		if (Input.GetKey(KeyCode.S))
		{
			t.Translate(Vector3.back * baseCharacterInformation.GetMoveSpeed() * Time.deltaTime);
			baseCharacterInformation.anim.SetBool("IsRun", true);
		}

		if (Input.anyKey == false)
		{
			baseCharacterInformation.anim.SetBool("IsRun", false);
		}
			

	}
	public bool Userskill(int skillNumber)
	{
		if (isSkillsCoolTime[skillNumber])
			return true;

		return false;
	}

	public int Getskill(int skillNumber)
	{
		return skills[skillNumber];
	}

	public bool IsCoolTime(int skillNumber)
	{
		return isSkillsCoolTime[skillNumber];
	}

	public void LevelUp()
	{

	}

	public void Jump(ref JumpState  jumpState, int jumpSpeed)
	{

		switch (jumpState)
		{ 
			case JumpState.OneJump:
				rigidbody.AddForce(Vector3.up * jumpSpeed);
				jumpState = JumpState.TwoJump;
				break;
			case JumpState.TwoJump:
				rigidbody.AddForce(Vector3.up * jumpSpeed);
				jumpState = JumpState.UnJump;
				break;
		}
	}
	public int GetExp()
	{
		return Exp;
	}

	public bool Revival()
	{
		return false;
	}

	public void SetJumpSpeed(int jumpSeed)
	{
		this.jumpSpeed = jumpSeed;
	}

	public int GetJumpSpeed()
	{
		return jumpSpeed;
	}


}
