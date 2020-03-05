﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

	public GameObject ui;

	public Text upgradeCost;
	public Button upgradeButton;

	public Text sellAmount;
	private Node target;

	public void SetTarget(Node _target){
		target = _target;
		if (target.levelTower==0) {
			upgradeCost.text = "$" + target.turretBlueprint.upgradeCostLevel1;
			upgradeButton.interactable = true;
		} else if(target.levelTower==1){
			upgradeCost.text = "$" + target.turretBlueprint.upgradeCostLevel2;
			upgradeButton.interactable = true;
		} else {
			upgradeCost.text = "DONE";
			upgradeButton.interactable = false;
		}

		sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
			
		ui.SetActive (true);
	}

	public void Hide(){
		ui.SetActive (false);
	}

	public void Upgrade(){
		target.UpgradeTurret ();
		BuildManager.instance.DeselectNode ();
	}

	public void Sell(){
		target.SellTurret ();
		BuildManager.instance.DeselectNode ();
	}
		
}
