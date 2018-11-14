using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

	public GameObject[] playerportrade;
	public GameObject[] firtmenuSelec;
	public CombatManager cm;
	public int firtCont = 0;
	public GameObject combatmenucontainer;
	public GameObject[] combatmenu;
	[SerializeField]
	private GameObject selectetCharacter;
	private GameObject selectetEnemy;
	[SerializeField]
	private int menulvl = 0;
	private ArrayList attackenemts;
	private bool selectingenemy = false;
	private int curTurn=1;
	private int actualpos = 0;

	private void Start()
	{
		attackenemts = new ArrayList();
		setfirtenemy();
	}
	private void Update()
	{
		bool a = Input.GetKeyDown(KeyCode.A);
	
		if (!Input.anyKey)
			return;
		if (Input.GetKeyDown(KeyCode.UpArrow) && !selectingenemy)
			moveFirtMenu(-1);
		else if (Input.GetKeyDown(KeyCode.DownArrow) && !selectingenemy)
			moveFirtMenu(1);
		else if (Input.GetKeyDown(KeyCode.A) && menulvl == 0 && firtCont == 0 && !selectingenemy)
			activeCombatMenu();

		else if ( a && menulvl == 1 && firtCont == 0 && !selectingenemy)
		{
			selectingenemy = true;
			selectetCharacter = cm.getplayer();
			getSelectingEnemy(actualpos, selectetCharacter.GetComponent<Character>().basicattack.numberOfEnemys);
			a = false;
		}
		else if (Input.GetKeyDown(KeyCode.B) && menulvl == 1 && !selectingenemy)
			disbleCombatMenu();
		if (selectingenemy)
			selectingEnemy(); 
	}
	public void initCombate(GameObject[] players)
	{
		for(int i =0;i<players.Length;i++)
		{
			GameObject pj = players[i];
			if(pj!=null)
			{
				uptadePortraid(i, pj.GetComponent<Character>());
			}
			else
			{
				return;
			}
		}
	}


	private void uptadePortraid(int pos,Character ch)
	{

		GameObject ui = playerportrade[pos];
		Text name = ui.transform.Find("Name").GetComponent<Text>();
		name.text = ch.Pjname;
		Slider lifeS = ui.transform.Find("lifeslider").GetComponent<Slider>();
		Slider manaS = ui.transform.Find("manaslider").GetComponent<Slider>();
		lifeS.value = ch.CurrentLife/ ch.MaxLife;
		manaS.value = ch.CurrentMana / ch.MaxMana;
		Text tLife = ui.transform.Find("MaxLife").GetComponent<Text>();
		Text tmana = ui.transform.Find("MAXmana").GetComponent<Text>();
		tLife.text = ch.CurrentLife.ToString() + "/" + ch.MaxLife.ToString();
		tmana.text = ch.CurrentMana.ToString() + "/" + ch.MaxMana.ToString();
		ui.SetActive(true);

	}

	public void moveFirtMenu(int n)
	{
		if(menulvl==0)
		{
			if (n > 0)
			{
				if (firtCont + 1 > firtmenuSelec.Length - 1)
				{
					firtmenuSelec[firtCont].SetActive(false);
					firtCont = 0;
					firtmenuSelec[firtCont].SetActive(true);
				}
				else
				{
					firtmenuSelec[firtCont].SetActive(false);
					firtCont++;
					firtmenuSelec[firtCont].SetActive(true);
				}
			}
			else
			{
				if (firtCont - 1 < 0)
				{
					firtmenuSelec[firtCont].SetActive(false);
					firtCont = firtmenuSelec.Length - 1;
					firtmenuSelec[firtCont].SetActive(true);
				}
				else
				{
					firtmenuSelec[firtCont].SetActive(false);
					firtCont--;
					firtmenuSelec[firtCont].SetActive(true);
				}
			}

		}
		else if(menulvl==1)
		{
			if (n > 0)
			{
				if (firtCont + 1 > combatmenu.Length - 1)
				{
					combatmenu[firtCont].SetActive(false);
					firtCont = 0;
					combatmenu[firtCont].SetActive(true);
				}
				else
				{
					combatmenu[firtCont].SetActive(false);
					firtCont++;
					combatmenu[firtCont].SetActive(true);
				}
			}
			else
			{
				if (firtCont - 1 < 0)
				{
					combatmenu[firtCont].SetActive(false);
					firtCont = combatmenu.Length - 1;
					combatmenu[firtCont].SetActive(true);
				}
				else
				{
					combatmenu[firtCont].SetActive(false);
					firtCont--;
					combatmenu[firtCont].SetActive(true);
				}
			}
		}
	
	}

	public void selectingEnemy()
	{
		if(Input.GetKeyDown(KeyCode.Y))
		{
			
			Character c = selectetCharacter.GetComponent<Character>();
			int pdmg = c.Attack + c.basicattack.physicDmg;
			getSelectingEnemy(actualpos,c.basicattack.numberOfEnemys);
			Action o = new Action(attackenemts, selectetCharacter, pdmg, 0, 0, 0, 0, 0, 0,0);
			c.currentAction = o;
			cm.queTurn(c);
			cm.advanceselct(1);
			selectetCharacter = cm.getplayer();
			selectingenemy = false;
			setfirtenemy();
			if (curTurn == cm.NumberofPlayer)
			{
				Debug.Log("turno termino");
				curTurn = 1;
				cm.createcombatqueve();
				resetturn();
			}
			else
				curTurn++;
		}
		if (Input.GetKeyDown(KeyCode.V))
		{
			advanceEnemy(1);
			getSelectingEnemy(actualpos, selectetCharacter.GetComponent<Character>().basicattack.numberOfEnemys);

		}
		if (Input.GetKeyDown(KeyCode.C))
		{

			advanceEnemy(-1);
			getSelectingEnemy(actualpos, selectetCharacter.GetComponent<Character>().basicattack.numberOfEnemys);

		}

	}
	public void activeCombatMenu()
	{
		menulvl++;
		firtCont = 0;
		selectetCharacter = cm.getplayer();
		combatmenucontainer.SetActive(true);

	}
	public void disbleCombatMenu()
	{
		menulvl--;
		firtCont = 0;
		combatmenu[0].SetActive(true);
		selectetCharacter = null;
		for (int i=1;i<combatmenu.Length;i++)
		{
			combatmenu[i].SetActive(false);
		}
		combatmenucontainer.SetActive(false);

	}


	private void getSelectingEnemy(int pos,int numTargets)
	{
		
		foreach (GameObject x in attackenemts)
		{
			x.GetComponent<Character>().pointer.SetActive(false);
		}

		attackenemts = cm.getEnemy(pos, numTargets);

		foreach (GameObject x in attackenemts)
		{
			x.GetComponent<Character>().pointer.SetActive(true);
		}
		
	}

	private void setfirtenemy()
	{
		GameObject[] x = cm.enemis;
	
		for(int i=0;i<x.Length;i++)
		{
			if(x[i]!=null)
			{
				actualpos = i;
				break;
			}
		}
		
	}

	private void advanceEnemy(int dir )
	{
		GameObject[] x = cm.enemis;
		bool y = false;

		if (dir == 1)
		{
			int i = actualpos + 1;
			while (!y)
			{
				if (i > x.Length-1)
					i = 0;
				if (x[i] != null)
					y = true;
				else
					i++;
			}
			actualpos = i;
		}
		else
		{
			int i = actualpos - 1;
			while (!y)
			{
				if (i < 0)
					i = x.Length-1;
				if (x[i] != null)
					y = true;
				else
					i--;
			}
			actualpos = i;
		}
	}
	public void resetturn()
	{
		disbleCombatMenu();
	}
}
