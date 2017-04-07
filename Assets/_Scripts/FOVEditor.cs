﻿using UnityEngine;
using System.Collections;
using UnityEditor;

/*
 * CopFOVEditor
 * Edits the city's camera GUI to make it visible in the scene and game modes
 */

[CustomEditor (typeof (CameraFOV))]
public class FOVEditor : Editor {

	void OnSceneGUI() {
		CameraFOV fow = (CameraFOV)target;
		Handles.color = Color.white;
		Handles.DrawWireArc (fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadius);
		Vector3 viewAngleA = fow.DirFromAngle (-fow.viewAngle / 2, false);
		Vector3 viewAngleB = fow.DirFromAngle (fow.viewAngle / 2, false);

		Handles.DrawLine (fow.transform.position, fow.transform.position + viewAngleA * fow.viewRadius);
		Handles.DrawLine (fow.transform.position, fow.transform.position + viewAngleB * fow.viewRadius);

		Handles.color = Color.red;
		foreach (Transform visibleTarget in fow.visibleTargets) {
			Handles.DrawLine (fow.transform.position, visibleTarget.position);
		}
	}

}