using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

	private Transform target;
	private int wavepointIndex = 0;

	private Enemy enemy;

	public int spawnAt;

	void Start (){
		enemy = GetComponent<Enemy> ();

		if(spawnAt==0){
			target = Waypoints.points [0];
		}else if(spawnAt==1){
			target = Waypoints.points2 [0];
		}else if(spawnAt==2){
			target = Waypoints.points3 [0];
		}else if(spawnAt==3){
			target = Waypoints.points4 [0];
		}

	}

	void Update (){
		if(!enemy.isDead){
			Vector3 dir = target.position - transform.position;
			Quaternion lookRotation = Quaternion.LookRotation(dir);
			Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * enemy.speed).eulerAngles;
			transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
			transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
			if (Vector3.Distance(transform.position, target.position) <= 0.4f)
			{
				GetNextWayPoint();
			}
			enemy.speed = enemy.startSpeed;
		}
	}

	void GetNextWayPoint(){
		if(spawnAt==0){
			if(wavepointIndex >= Waypoints.points.Length -1){
				EndPath ();
				return;
			}
		}else if(spawnAt==1){
			if(wavepointIndex >= Waypoints.points2.Length -1){
				EndPath ();
				return;
			}
		}else if(spawnAt==2){
			if(wavepointIndex >= Waypoints.points3.Length -1){
				EndPath ();
				return;
			}
		}else if(spawnAt==3){
			if(wavepointIndex >= Waypoints.points4.Length -1){
				EndPath ();
				return;
			}
		}
		wavepointIndex++;
		if(spawnAt==0){
			target = Waypoints.points [wavepointIndex];
		}else if(spawnAt==1){
			target = Waypoints.points2 [wavepointIndex];
		}else if(spawnAt==2){
			target = Waypoints.points3 [wavepointIndex];
		}else if(spawnAt==3){
			target = Waypoints.points4 [wavepointIndex];
		}
	}

	void EndPath(){
		PlayerStatus.Lives--;
		WaveSpawner.EnemiesAlive--;
		Destroy (gameObject);
	}

	public void SetSpawnAt(int index){
		spawnAt = index;
	}

	public void GetSpawnAt(){
		print(spawnAt);
	}
}
