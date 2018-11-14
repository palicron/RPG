using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action  {

	public ArrayList Target;
	private GameObject Origin;
	public int physicDmg;
	private int fireDmg;
	private int waterDmg;
	private int erathDmg;
	private int windDmg;
	private int lightDmg;
	private int ShadowDmg;
	private int bonusspeed;

	public Action(ArrayList target, GameObject origin,int Pdmg,int fDmg, int eDmg,int wDmg,int wiDmg,int lDmg,int ShDmg,int speed)
	{
		this.Target = target;
		this.Origin = origin;
		this.physicDmg = Pdmg;
		this.fireDmg = fDmg;
		this.erathDmg = eDmg;
		this.waterDmg = wDmg;
		this.windDmg = wiDmg;
		this.lightDmg = lDmg;
		this.ShadowDmg = ShDmg;
		this.bonusspeed = speed;
	}


}

public enum ElementTypes
{
	Fire,Water,Wind,Earth,Physic,Light,Dark
}

public class ElementDefence
{

	public int defence;
	public ElementTypes element;

	public ElementDefence(int def, ElementTypes el)
	{
		defence = def;
		element = el;
	}
}
public enum AttackTipes
{
	Attack,HealAlly,Buff,DeBuff,HealAll,Defence
}
