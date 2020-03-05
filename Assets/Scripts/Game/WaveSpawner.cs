using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public static int EnemiesAlive = 0;

	public Wave[] waves;

	public Transform[] spawnPoint;

	public float timeBetweenWaves = 30f;
	private float countdown = 2f;

	public Text waveCountdownText;

	private int waveIndex = 0;

	public GameManager gameManager;

	public string enemyTag = "Enemy";
	private EnemyMovement targetEnemy;
	private float range = 15f;


	void Update(){
		if (EnemiesAlive > 0) {
			return;
		}
		if (waveIndex == waves.Length)
		{
			gameManager.Win ();
			this.enabled = false;
		}
		if (countdown <= 0f) {
			StartCoroutine(SpawnWave ());
			countdown = timeBetweenWaves;
			return;
		}
		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp (countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format ("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave(){
		PlayerStatus.Rounds++;

		Wave wave = waves [waveIndex];

		for(int i = 0 ; i < wave.count ; i++){
			SpawnEnemy (wave.enemy);
			EnemiesAlive++;
			yield return new WaitForSeconds (1f / wave.rate);
		}
		waveIndex++;
	}

	void SpawnEnemy(GameObject enemyPrefab){
		if (PhotonNetwork.isMasterClient) {
			for (int index = 0; index < spawnPoint.Length; index++) {
				if (waveIndex % 5 == 0) {
					PhotonNetwork.Instantiate (enemyPrefab.name, spawnPoint [index].position, spawnPoint [index].rotation, 0);
				}if (waveIndex % 5 == 1) {
					PhotonNetwork.Instantiate (enemyPrefab.name, spawnPoint [index].position, spawnPoint [index].rotation, 0);
				}if (waveIndex % 5 == 2) {
					PhotonNetwork.Instantiate (enemyPrefab.name, spawnPoint [index].position, spawnPoint [index].rotation, 0);
				}if (waveIndex % 5 == 3) {
					PhotonNetwork.Instantiate (enemyPrefab.name, spawnPoint [index].position, spawnPoint [index].rotation, 0);
				}if (waveIndex % 5 == 4) {
					PhotonNetwork.Instantiate (enemyPrefab.name, spawnPoint [index].position, spawnPoint [index].rotation, 0);
				}
				GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag);
				float shortesDistance = Mathf.Infinity;
				GameObject nearestEnemy = null;
				foreach (GameObject enemy in enemies) {
					float distanceToEnemy = Vector3.Distance (spawnPoint [index].position, enemy.transform.position);
					if (distanceToEnemy < shortesDistance) {
						shortesDistance = distanceToEnemy;
						nearestEnemy = enemy;
					}
				}
				if (nearestEnemy != null && shortesDistance <= range) {
					targetEnemy = nearestEnemy.GetComponent<EnemyMovement> ();
					SetEnemy (index);
					targetEnemy.GetSpawnAt ();
				}
			}
		}
	}

	void SetEnemy(int index){
		targetEnemy.SetSpawnAt(index);
	}
}
