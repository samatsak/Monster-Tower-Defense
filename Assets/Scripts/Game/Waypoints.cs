using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {

	public Transform[] waypoint;
	public static Transform[] points;
	public static Transform[] points2;
	public static Transform[] points3;
	public static Transform[] points4;

	void Awake(){
		if(waypoint.Length==4){
			points = new Transform[waypoint[0].childCount];
			for (int i = 0; i < points.Length; i++) {
				points [i] = waypoint[0].GetChild (i);
			}
			points2 = new Transform[waypoint[1].childCount];
			for (int i = 0; i < points2.Length; i++) {
				points2 [i] = waypoint[1].GetChild (i);
			}
			points3 = new Transform[waypoint[2].childCount];
			for (int i = 0; i < points3.Length; i++) {
				points3 [i] = waypoint[2].GetChild (i);
			}
			points4 = new Transform[waypoint[3].childCount];
			for (int i = 0; i < points4.Length; i++) {
				points4 [i] = waypoint[3].GetChild (i);
			}
		}else if(waypoint.Length==2){
			points = new Transform[waypoint[0].childCount];
			for (int i = 0; i < points.Length; i++) {
				points [i] = waypoint[0].GetChild (i);
			}
			points2 = new Transform[waypoint[1].childCount];
			for (int i = 0; i < points2.Length; i++) {
				points2 [i] = waypoint[1].GetChild (i);
			}
		}else if(waypoint.Length==1){
			points = new Transform[waypoint[0].childCount];
			for (int i = 0; i < points.Length; i++) {
				points [i] = waypoint[0].GetChild (i);
			}
		}

	}
}
