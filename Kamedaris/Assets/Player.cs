using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Sys = System;
using Pillo;

public class Player : MonoBehaviour {
		

	private float[] newSmooth = new float[4];
	private float[] oldSmooth = new float[4];
	private const float OFFSET =0.3f;
	
	public float smoothFactor = 0.1f;


	private void Update(){
		if (Input.GetKey (KeyCode.Escape)) {
			Application.LoadLevel("Menu");
		}
	}





	void FixedUpdate () {
		try
		{
			float f1 = (f_update(PilloID.Pillo1)*-1) + OFFSET;
			float f2 = (f_update(PilloID.Pillo2)*-1) + OFFSET;

			
		} catch (Sys.Exception e)
		{
			Debug.Log(e.Message); // failsafe; notify user
		}

	}


	float f_update(Pillo.PilloID pillo)
	{
		PilloController.GetSensor(pillo);
		if(PilloController.GetSensor(pillo)<10){
			newSmooth[(int)pillo] = (PilloController.GetSensor(pillo)/70)*100;
		}else if(PilloController.GetSensor(pillo)>90){
			newSmooth[(int)pillo]=1;
		}

		
		float tempFloat = newSmooth[(int)pillo] * smoothFactor + oldSmooth[(int)pillo]*(1-smoothFactor);
		oldSmooth[(int)pillo] = tempFloat;
		
		//tempfloat = smoothed value
		return tempFloat;
	}





}
