using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

	public TurretBluePrint turret1Prefab;
	public TurretBluePrint turret2Prefab;
	public TurretBluePrint turret3Prefab;
	public TurretBluePrint turret4Prefab;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

	public void SelectTurret1Prefab()
    {
		Debug.Log("Turret1Prefab Selected");
		buildManager.SelectTurretToBuild(turret1Prefab);
    }

	public void SelectTurret2Prefab()
    {
		Debug.Log("Turret2Prefab Selected");
		buildManager.SelectTurretToBuild(turret2Prefab);
    }

	public void SelectTurret3Prefab()
	{
		Debug.Log("Turret3Prefab Selected");
		buildManager.SelectTurretToBuild(turret3Prefab);
	}

	public void SelectTurret4Prefab()
	{
		Debug.Log("Turret4Prefab Selected");
		buildManager.SelectTurretToBuild(turret4Prefab);
	}
}
