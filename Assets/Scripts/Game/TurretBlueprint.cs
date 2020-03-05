using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBluePrint {

	public GameObject prefab;
	public int cost;

	public GameObject upgradedPrefabLevel1;
	public int upgradeCostLevel1;

	public GameObject upgradedPrefabLevel2;
	public int upgradeCostLevel2;

	public int GetSellAmount(){
		return cost / 2;
	}
		
}
