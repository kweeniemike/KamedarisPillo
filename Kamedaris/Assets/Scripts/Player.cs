﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Sys = System;
using Pillo;

public class Player : MonoBehaviour {

	private float[] newSmooth = new float[4];
	private float[] oldSmooth = new float[4];
	private const float OFFSET =0.3f;
	
	public float smoothFactor = 0.1f;

	public float pilloPressure1;
	public float pilloPressure2;



	private void Update(){
		if (Input.GetKey (KeyCode.Escape)) {
			Application.LoadLevel("Menu");
		}
	}

	void FixedUpdate () {
		try
		{
			pilloPressure1 = (f_update(PilloID.Pillo1));
			pilloPressure2 = (f_update(PilloID.Pillo2));
			                  //*-1) + OFFSET
			
		} catch (Sys.Exception e)
		{
			Debug.Log(e.Message); // failsafe; notify user
		}

	}


	float f_update(Pillo.PilloID pillo)
	{
		Vector3 acceleration = PilloController.GetAccelero(pillo);
		float angleX = Vector3.Angle (Vector3.right, acceleration) - 90;
		float angleZ = Vector3.Angle (Vector3.up, acceleration) - 90;
		Quaternion accelQ = Quaternion.Euler (angleX, 0, angleZ);
		float accelZ = accelQ.eulerAngles.z;
		//Debug.Log (accelZ);
		//Debug.Log("Accelz" + acceleration);
		//Debug.Log (PilloController.GetSensor (pillo));
		PilloController.GetSensor(pillo);
		if (PilloController.GetSensor (pillo) < 0.1f) {
			newSmooth [(int)pillo] = 0.1f;
			oldSmooth[(int)pillo] = 0.1f;
		} else if (PilloController.GetSensor (pillo) > 0.9f) {
			newSmooth [(int)pillo] = 0.9f;
			oldSmooth[(int)pillo] = 0.9f;
		} else {
			newSmooth[(int)pillo] = (PilloController.GetSensor(pillo)/100)*100;
		}

		
		float tempFloat = newSmooth[(int)pillo] * smoothFactor + oldSmooth[(int)pillo]*(1-smoothFactor);
		oldSmooth[(int)pillo] = tempFloat;
		
		//tempfloat = smoothed value
		return tempFloat;
	}





}
