using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

	public int id;
	[SerializeField]
	private string pjname;
	[SerializeField]
	private int maxLife;
	[SerializeField]
	private int currentLife;
	[SerializeField]
	private int maxMana;
	[SerializeField]
	private int currentMana;
	[SerializeField]
	private int level;
	[SerializeField]
	private int experience;
	private bool starCount=false;
	private bool alive;
	[SerializeField]
	private int strenge;
	[SerializeField]
	private int agility;
	[SerializeField]
	private int intelligence;
	private int speed;
	private int attack;
	private int defend;
	public Action currentAction = null;
	public CharacterStats initStats;
	public AttackAction basicattack;
	public GameObject pointer;
	public void init()
	{
		if(!starCount)
		{
			pjname = initStats.names;
			maxLife = initStats.maxLife;
			currentLife = maxLife;
			maxMana = initStats.maxMana;
			currentMana = maxMana;
			experience = initStats.experience;
			alive = true;
			speed = initStats.speed;
			attack = initStats.attack;
			defend = initStats.defend;
			strenge = initStats.strenge;
			agility = initStats.agility;
			intelligence = initStats.intelligence;

		}
	}

	public void takeDmg(Action dmg)
	{
		currentLife -= dmg.physicDmg - this.defend;
	}

	public int gainExp(int gainExp)
	{
		return experience;
	}

	private void levelUp()
	{

	}
	public void executeAction()
	{
		ArrayList en = currentAction.Target;
		for(int i=0;i<en.Count;i++)
		{
			GameObject og = (GameObject)en[i];
			Character cd = og.GetComponent<Character>();
			if(cd!=null)
			{
				cd.takeDmg(currentAction);
			}
		}
		CombatManager.Instace.inAction = false;
	}


	///////////////Getter and Setters/////////////////////////////
	///


	public int CurrentLife
	{
		get
		{
			return currentLife;
		}

		set
		{
			currentLife = value;
		}
	}

	public int CurrentLife1
	{
		get
		{
			return currentLife;
		}

		set
		{
			currentLife = value;
		}
	}

	public int MaxMana
	{
		get
		{
			return maxMana;
		}

		set
		{
			maxMana = value;
		}
	}

	public int CurrentMana
	{
		get
		{
			return currentMana;
		}

		set
		{
			currentMana = value;
		}
	}

	public int Level
	{
		get
		{
			return level;
		}

		set
		{
			level = value;
		}
	}

	public int Experience
	{
		get
		{
			return experience;
		}

		set
		{
			experience = value;
		}
	}

	public bool StarCount
	{
		get
		{
			return starCount;
		}

		set
		{
			starCount = value;
		}
	}

	public bool Alive
	{
		get
		{
			return alive;
		}

		set
		{
			alive = value;
		}
	}

	public int Speed
	{
		get
		{
			return speed;
		}

		set
		{
			speed = value;
		}
	}

	public int Attack
	{
		get
		{
			return attack;
		}

		set
		{
			attack = value;
		}
	}

	public int Defend
	{
		get
		{
			return defend;
		}

		set
		{
			defend = value;
		}
	}

	public int MaxLife
	{
		get
		{
			return maxLife;
		}

		set
		{
			maxLife = value;
		}
	}

	public string Pjname
	{
		get
		{
			return pjname;
		}

		set
		{
			pjname = value;
		}
	}

	public int Strenge
	{
		get
		{
			return strenge;
		}

		set
		{
			strenge = value;
		}
	}

	public int Agility
	{
		get
		{
			return agility;
		}

		set
		{
			agility = value;
		}
	}

	public int Intelligence
	{
		get
		{
			return intelligence;
		}

		set
		{
			intelligence = value;
		}
	}
}
