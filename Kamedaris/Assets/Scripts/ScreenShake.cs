using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

	private Vector3 oldTransformation;
	private Quaternion oldRotation;
	private Vector3 startTransformation;
	private Quaternion startRotation;
	private float timer = 0.0f;


	private void Awake()
	{
		//set the default rotation
		oldRotation = this.transform.rotation;
		oldTransformation = this.transform.position;

		startRotation = this.transform.rotation;
		startTransformation = this.transform.position;

		return;
	}


	public void Shake(float time){
		timer = Time.timeSinceLevelLoad + time;
	}

	private void Update(){
		//update the position
		oldTransformation = this.transform.position;
	
		//shake the camera until the times runs out
		if (Time.timeSinceLevelLoad < timer&&Time.timeScale==1)
		{
			ShakeCamera(0.012f, 0.004f);
		}else if(this.transform.rotation!=startRotation||this.transform.position!=startTransformation){
			this.transform.rotation = startRotation;
			this.transform.position = startTransformation;
		}
		
	}


	private void ShakeCamera(float shakeIntensity, float shakeDecay)
	{
		//get a random position
		this.transform.position = oldTransformation + Random.insideUnitSphere * shakeIntensity;
		
		//rotate
		this.transform.rotation = new Quaternion(oldRotation.x + Random.Range(-shakeIntensity, shakeIntensity) * 0.2f,
		                                         oldRotation.y + Random.Range(-shakeIntensity, shakeIntensity) * 0.2f,
		                                         oldRotation.z + Random.Range(-shakeIntensity, shakeIntensity) * 0.2f,
		                                         oldRotation.w + Random.Range(-shakeIntensity, shakeIntensity) * 0.2f);
		//decay
		shakeIntensity -= shakeDecay;
		
		return;
	}


}
