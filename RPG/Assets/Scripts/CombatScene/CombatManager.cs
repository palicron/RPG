using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {

	private static CombatManager intace;
	private CombatArray<Character> comarr;
	public int arrSize = 7;
	private int cont = 0;
	public Transform[] playerSlots;
	public Transform[] enemisSlots;
	public GameObject[] playerspre;
	public GameObject[] players;
	public GameObject[] enemipre;
	public GameObject[] enemis;
	public UIManager uiMan;
	public GameObject[] selectettargetindic;
	[SerializeField]
	private int SelectPost = 0;
	[SerializeField]
	public int EnemySelcPost = 0;
	[SerializeField]
	private int turn = 0;

	private int numberofPlayer=0;
	private int numberofEnemys = 0;

	public bool starTurn=false;
	public bool inAction = false;

	// Use this for initialization
	void Awake(){
		intace = this;
		comarr = new CombatArray<Character>(arrSize);

		bool s = true;
		bool t = true;
		for (int i =0;i<playerspre.Length && s;i++)
		{
			if (playerspre[i] == null)
			{
				s = false;
			}
			else
			{
				players[i] = GameObject.Instantiate(playerspre[i], playerSlots[i].transform.position, playerSlots[i].transform.rotation);
				players[i].GetComponent<Character>().init();
				numberofPlayer++;
			}

		}


		for (int i = 0; i < enemipre.Length && t; i++)
		{
			if (enemipre[i] == null)
			{
				t = false;
			}
			else
			{
				enemis[i] = GameObject.Instantiate(enemipre[i], enemisSlots[i].transform.position, enemisSlots[i].transform.rotation);
				enemis[i].GetComponent<Character>().init();
				numberofEnemys++;
			}

		}
		uiMan.initCombate(players);
		Debug.Log(comarr);
		
	}
	
	public  static CombatManager Instace
	{
		get
		{
			if(intace == null)
			{
				intace = new CombatManager();
			}
			return intace;
		}
	}
	// Update is called once per frame
	void Update () {

		if (!starTurn)
			return;
		else
		{
			
			executeTurn();
		}
		
	}


	public void advanceselct(int n)
	{
		if (n > 0)
		{
			if(SelectPost+1> numberofPlayer - 1)
			{

				SelectPost = 0;
			}
			else
			{
				
				
				
					SelectPost++;
				
			}
		}		
		else
		{
			
			if (SelectPost - 1 < 0)
			{
			
				SelectPost = numberofPlayer - 1;
			}
			else
			{
			
					SelectPost--;
				
			}
		}
		
	}


	public void advanceselcenemy(int n)
	{
		if (n > 0)
		{
			if (EnemySelcPost + 1 > numberofEnemys - 1)
			{

				EnemySelcPost = 0;
			}
			else
			{
		
					EnemySelcPost++;
			
			}
		}
		else
		{
			
			if (SelectPost - 1 < 0)
			{
	
				EnemySelcPost = numberofEnemys - 1;
			}
			else
			{

				EnemySelcPost--;

			}
		}

	}
	public GameObject getplayer()
	{
		return players[SelectPost];
	}
	public ArrayList getEnemy(int n)
	{
		ArrayList g = new ArrayList();
		if(n==-1 || n>numberofEnemys) 
		{
			for(int i =0;i<enemis.Length;i++)
			{
				g.Add(enemis[i]);
			}
		}
		else if(n==1)
		{
			g.Add(enemis[EnemySelcPost]);
		}
		return g;
	}

	public void queTurn(Character c)
	{
		int tspeed = c.Speed;
		comarr.insert(c, tspeed);
	}

	public int NumberofPlayer
	{
		get
		{
			return numberofPlayer;
		}

		set
		{
			numberofPlayer = value;
		}
	}

	public int SelectPost1
	{
		get
		{
			return SelectPost;
		}

		set
		{
			SelectPost = value;
		}
	}
	public void createcombatqueve()
	{
		comarr.createcombatsequece();
		starTurn = true;
	}

	private void executeTurn()
	{
		if (inAction)
			return;

		Character turn = comarr.getTurn();
		if(turn==null)
		{
			starTurn = false;
			Debug.Log("termiune wiii");
		}
		else
		{
			inAction = true;
			turn.executeAction();
		}
		
		
	}
}
