using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability/Attack")]
public class AttackAction : ScriptableObject {

	public string nombre;
	public int physicDmg;
	public int fireDmg;
	public int waterDmg;
	public int erathDmg;
	public int windDmg;
	public int lightDmg;
	public int ShadowDmg;

	public float critMultiplayer;
	[Range(0,1)]
	public float critChange;


	public string Asociteanimation;
	public string AsocietaCritAnimation;
	public int manacost;
	public int speedattack;
	[Range(0, 1)]
	public float misschange;
	public int numberOfEnemys;
	public AttackTipes tipe;

}
