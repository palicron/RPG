using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Character",menuName ="Character/Player")]
public class CharacterStats : ScriptableObject {

	public int id;
	public int maxLife;
	public string names;
	public int maxMana;
	public int level;
	public int experience;
	public bool alive;
	public int speed;
	public int attack;
	public int defend;
	public int strenge;
	public int agility;
	public int intelligence;
	public int fireResitance;
	public int waterResitance;
	public int earthResitance;
	public int windResitance;
	public int lightResitance;
	public int shadowResitance;

}
