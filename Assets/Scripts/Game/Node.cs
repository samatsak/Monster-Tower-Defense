using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {
	public AudioSource buildSound;
	public AudioSource sellTowerSound ;

    public Color hoverColor;
	public Color notEnoughMoneyColor;
	public Color[] playerColor;
    public Vector3 positionOffset;

	[HideInInspector]
    public GameObject turret;
	[HideInInspector]
	public TurretBluePrint turretBlueprint;
	[HideInInspector]
	public int levelTower = 0;

    private Renderer rend;
    private Color startColor;
	private Color changeColor;

    BuildManager buildManager;

	public PhotonPlayer PhotonPlayer { get; private set;}

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
		changeColor = startColor;
        buildManager = BuildManager.instance;
    }

	public Vector3 GetBuildPosition() {
		return transform.position + positionOffset;	
	}

    private void OnMouseDown()
    {
        if (turret != null)
        {
			buildManager.SelectNode (this);
            return;
        }

		if (!buildManager.CanBuild)
			return;

		BuildTurret (buildManager.GetTurretToBuild());
    }

	void BuildTurret (TurretBluePrint blueprint){
		if(PlayerStatus.Money < blueprint.cost){
			Debug.Log ("Not enough money to build that");
			return;
		}
		//addSound
		buildSound.Play();
		PlayerStatus.Money -= blueprint.cost;

		GameObject _turret = (GameObject)PhotonNetwork.Instantiate (blueprint.prefab.name, GetBuildPosition(), Quaternion.identity,0);
		turret = _turret;

		turretBlueprint = blueprint;

		GameObject effect = (GameObject)PhotonNetwork.Instantiate (buildManager.buildEffect.name, GetBuildPosition (), Quaternion.identity,0);
		Destroy (effect, 5f);

		if(blueprint.cost==2500){
			levelTower = 2;
		}

		Debug.Log ("ID:"+PlayerListing.playerId);

		rend.material.color = playerColor[PlayerListing.playerId];
		changeColor = playerColor[PlayerListing.playerId];

		Debug.Log ("Turret build!");

		buildManager.clearTurretToBuild ();
	}

	public void UpgradeTurret(){
		if(PlayerStatus.Money < turretBlueprint.upgradeCostLevel1 || PlayerStatus.Money < turretBlueprint.upgradeCostLevel2){
			Debug.Log ("Not enough money to upgrade that");
			return;
		}
		//addSound
		buildSound.Play();
		if (levelTower == 0) {
			PlayerStatus.Money -= turretBlueprint.upgradeCostLevel1;
		}if (levelTower == 1) {
			PlayerStatus.Money -= turretBlueprint.upgradeCostLevel2;
		}

		//Get rid of the old turret
		Destroy(turret);

		//Build a new one
		if(levelTower == 0){
			GameObject _turret = (GameObject)PhotonNetwork.Instantiate (turretBlueprint.upgradedPrefabLevel1.name, GetBuildPosition (), Quaternion.identity, 0);
			turret = _turret;
		}if(levelTower == 1){
			GameObject _turret = (GameObject)PhotonNetwork.Instantiate (turretBlueprint.upgradedPrefabLevel2.name, GetBuildPosition (), Quaternion.identity, 0);
			turret = _turret;
		}

		levelTower++;

		GameObject effect = (GameObject)PhotonNetwork.Instantiate (buildManager.buildEffect.name, GetBuildPosition (), Quaternion.identity, 0);
		Destroy (effect, 5f);

		Debug.Log ("Turret Upgraded!");
	}

	public void SellTurret(){
		PlayerStatus.Money += turretBlueprint.GetSellAmount();
		sellTowerSound.Play();

		GameObject effect = (GameObject)PhotonNetwork.Instantiate (buildManager.sellEffect.name, GetBuildPosition (), Quaternion.identity, 0);
		Destroy(effect, 5f);

		Destroy (turret);
		turretBlueprint = null;
		levelTower = 0;

		rend.material.color = startColor;
		changeColor = startColor;
	}

    private void OnMouseEnter()
    {
		if (!buildManager.CanBuild)
			return;

		if (buildManager.HasMoney) {
			rend.material.color = hoverColor;
		} else {
			rend.material.color = notEnoughMoneyColor;
		}

    }

    private void OnMouseExit()
    {
		rend.material.color = changeColor;   
    }
}
