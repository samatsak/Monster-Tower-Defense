using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

	public static int Money;
	public int startMoney = 400;

	public static int Lives;
	public int startLives = 20;

	public static int Kill;
	public int startKill = 0;

	public static int TotalMoney;

	public static int Rounds;

	void Start ()
	{
		Money = startMoney;
		Lives = startLives;
		Kill = startKill;
		TotalMoney = startMoney;
		Rounds = 0;
	}
}
