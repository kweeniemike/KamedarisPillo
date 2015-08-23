using UnityEngine;
using System.Collections;

public class BultControl : MonoBehaviour {
	public  bool fourPlayerMode = false;
	public GameObject bult01;
	public GameObject bult02;
	public GameObject bult03;
	public GameObject bult04;
	public GameObject bultLeft;
	public GameObject bultLeft2;
	public GameObject bultRight;
	public GameObject bultRight2;
	public GameObject bultdrie;
	public GameObject bultdrie2;
	public GameObject bultvier;
	public GameObject bultvier2;

	//public float newRotValue = 0f;
	public Player playerInputScript;
	//public float exMin = 0f;
	//public float exMax = 1.5f;
	private float moveMin = 0f;
	private float moveMax = 1.5f;

	//private float currentRotValue = 0f;
	//private bool rotating = false;

	//public float newExValue = 0f;
	//public float newExValue2 = 0f;
	//private float currentExValue = 0f;
	//private bool expanding = false;
	//private float currentExValue2 = 0f;
	//private bool expanding2 = false;

	private float newMoveValue = -1f;
	private float currentMoveValue = -1f;
	private bool moving = false;
	
	private float newMoveValue2 = -1f;
	private float currentMoveValue2 = -1f;
	private bool moving2 = false;
	
	private float newMoveValue3 = -1f;
	private float currentMoveValue3 = -1f;
	private bool moving3 = false;
	
	private float newMoveValue4 = -1f;
	private float currentMoveValue4 = -1f;
	private bool moving4 = false;

	//private Vector3 v3ToRot = Vector3.zero;
	//private Vector3 v3CurrentRot;
	private float speedRot = 5f;

	//private Vector3 v3ToEx = Vector3.zero;
	//private Vector3 v3CurrentEx;
	private float speedEx = 5f;
	private float speedMove = 0f;

	// Use this for initialization
	void Start () {
		moving = false;
		moving2 = false;
		if (fourPlayerMode) {
			moving3 = false;
			moving4 = false;
		}
		//v3CurrentRot = bult01.transform.eulerAngles;
		//v3CurrentEx = bult01.transform.localScale;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Score.gameEnded) {
			return;
		}

		if (!PilloController.pilloReady) {
			newMoveValue = Mathf.Clamp ( Input.GetAxis ("Vertical") * (moveMax - moveMin), moveMin, moveMax);
			newMoveValue2 = Mathf.Clamp ( Input.GetAxis ("Vertical2") * (moveMax - moveMin), moveMin, moveMax);
			//if (fourPlayerMode) {
			//	newMoveValue3 = Mathf.Clamp ( Input.GetAxis ("Vertical3") * (moveMax - moveMin), moveMin, moveMax);
			//	newMoveValue4 = Mathf.Clamp ( Input.GetAxis ("Vertical4") * (moveMax - moveMin), moveMin, moveMax);
			//}
		}else{
			newMoveValue = Mathf.Clamp (playerInputScript.pilloPressure1 * (moveMax - moveMin), moveMin, moveMax);
			newMoveValue2 = Mathf.Clamp (playerInputScript.pilloPressure2 * (moveMax - moveMin), moveMin, moveMax);
			if (fourPlayerMode) {
				newMoveValue3 = Mathf.Clamp (playerInputScript.pilloPressure3 * (moveMax - moveMin), moveMin, moveMax);
				newMoveValue4 = Mathf.Clamp (playerInputScript.pilloPressure4 * (moveMax - moveMin), moveMin, moveMax);
			}
		}


		//Debug.Log ("1" + moving + "-2" + moving2);
		/*
		if (playerInputScript.pilloPressure1 > 0.005f) {
			newExValue = Mathf.Clamp (playerInputScript.pilloPressure1 * (exMax - exMin)*1.5f, exMin, exMax);
		} else {
			newExValue = exMin;
		}
		if (playerInputScript.pilloPressure2 > 0.005f) {
			newExValue2 = Mathf.Clamp (playerInputScript.pilloPressure2 * (exMax - exMin)*1.5f, exMin, exMax);
		}
		else {
			newExValue2 = exMin;
		}

		//newExValue = Mathf.Clamp (playerInputScript.pilloPressure1, exMin, exMax);
		//newExValue2 = Mathf.Clamp (playerInputScript.pilloPressure2, exMin, exMax);
		//Debug.Log (newExValue + ";" + expanding);

		if (Mathf.Abs(newExValue - currentExValue) > 0.01f) {
			currentExValue = newExValue;
			StartCoroutine(Expand(currentExValue, bult01));
		}
		if (Mathf.Abs(newExValue2 - currentExValue2) > 0.01f) {
			currentExValue2 = newExValue2;
			StartCoroutine(Expand(currentExValue2, bult02));
		}
		/*/

		//if (playerInputScript.pilloPressure1 > 0.005f) {


		//} else {
			//newMoveValue = moveMin;
		//}
		//if (playerInputScript.pilloPressure2 > 0.005f) {


		//}
		//else {
			//newMoveValue2 = moveMin;
		//}
		
		if (Mathf.Abs(newMoveValue - currentMoveValue) > 0.01f && !moving) {

			currentMoveValue = newMoveValue;
			//StartCoroutine(MoveUpDown(currentMoveValue, bult01));
			moving = true;

		}
		if (Mathf.Abs(newMoveValue2 - currentMoveValue2) > 0.01f && !moving2) {

			currentMoveValue2 = newMoveValue2;
			//StartCoroutine(MoveUpDown2(currentMoveValue2, bult02));
			moving2 = true;
		}
		if (fourPlayerMode) {
			if (Mathf.Abs (newMoveValue3 - currentMoveValue3) > 0.01f && !moving3) {
			
				currentMoveValue3 = newMoveValue3;
				//StartCoroutine(MoveUpDown2(currentMoveValue2, bult02));
				moving3 = true;
			}
			if (Mathf.Abs (newMoveValue4 - currentMoveValue4) > 0.01f && !moving4) {
			
				currentMoveValue4 = newMoveValue4;
				//StartCoroutine(MoveUpDown2(currentMoveValue2, bult02));
				moving4 = true;
			}
		}

		if (moving) {
			Vector3 v3ToMove = new Vector3 (bult01.transform.position.x, currentMoveValue, bult01.transform.position.z);
			Vector3 v3ToMoveGraphic = new Vector3 (bult01.transform.position.x, currentMoveValue-0.67f, bult01.transform.position.z);
			Vector3 v3ToMoveGraphic2 = new Vector3 (bult01.transform.position.x, (currentMoveValue*0.75f)-1.35f, bult01.transform.position.z);
			Vector3 v3CurrentMove = bult01.transform.position;
			if(Vector3.Distance(v3ToMove, v3CurrentMove) > 0.005f) {
				bult01.GetComponent<Rigidbody> ().MovePosition (v3ToMove);
				bultLeft.GetComponent<Rigidbody> ().MovePosition (v3ToMoveGraphic);
				bultLeft2.GetComponent<Rigidbody> ().MovePosition (v3ToMoveGraphic2);
			}
			else
			{
				moving = false;
			}
		}

		if (moving2) {
			Vector3 v3ToMove2 = new Vector3 (bult02.transform.position.x, currentMoveValue2, bult02.transform.position.z);
			Vector3 v3ToMove2Graphic = new Vector3 (bult02.transform.position.x, currentMoveValue2-0.67f, bult02.transform.position.z);
			Vector3 v3ToMove2Graphic2 = new Vector3 (bult02.transform.position.x, (currentMoveValue2*0.75f)-1.35f, bult02.transform.position.z);
			Vector3 v3CurrentMove2 = bult02.transform.position;
			if(Vector3.Distance(v3ToMove2, v3CurrentMove2) > 0.005f) {
				bult02.GetComponent<Rigidbody> ().MovePosition (v3ToMove2);
				bultRight.GetComponent<Rigidbody> ().MovePosition (v3ToMove2Graphic);
				bultRight2.GetComponent<Rigidbody> ().MovePosition (v3ToMove2Graphic2);
			}
			else
			{
				moving2 = false;
			}
		}
		if (fourPlayerMode) {
			if (moving3) {
				Vector3 v3ToMove3 = new Vector3 (bult03.transform.position.x, currentMoveValue3, bult03.transform.position.z);
				Vector3 v3ToMove3Graphic = new Vector3 (bult03.transform.position.x, currentMoveValue3 - 0.67f, bult03.transform.position.z);
				Vector3 v3ToMove3Graphic2 = new Vector3 (bult03.transform.position.x, (currentMoveValue3 * 0.75f) - 1.35f, bult03.transform.position.z);
				Vector3 v3CurrentMove3 = bult03.transform.position;
				if (Vector3.Distance (v3ToMove3, v3CurrentMove3) > 0.005f) {
					bult03.GetComponent<Rigidbody> ().MovePosition (v3ToMove3);
					bultdrie.GetComponent<Rigidbody> ().MovePosition (v3ToMove3Graphic);
					bultdrie2.GetComponent<Rigidbody> ().MovePosition (v3ToMove3Graphic2);
				} else {
					moving3 = false;
				}
			}
		
			if (moving4) {
				Vector3 v3ToMove4 = new Vector3 (bult04.transform.position.x, currentMoveValue4, bult04.transform.position.z);
				Vector3 v3ToMove4Graphic = new Vector3 (bult04.transform.position.x, currentMoveValue4 - 0.67f, bult04.transform.position.z);
				Vector3 v3ToMove4Graphic2 = new Vector3 (bult04.transform.position.x, (currentMoveValue4 * 0.75f) - 1.35f, bult04.transform.position.z);
				Vector3 v3CurrentMove4 = bult04.transform.position;
				if (Vector3.Distance (v3ToMove4, v3CurrentMove4) > 0.005f) {
					bult04.GetComponent<Rigidbody> ().MovePosition (v3ToMove4);
					bultvier.GetComponent<Rigidbody> ().MovePosition (v3ToMove4Graphic);
					bultvier2.GetComponent<Rigidbody> ().MovePosition (v3ToMove4Graphic2);
				} else {
					moving4 = false;
				}
			}
		}
		
		//*/


		//Debug.Log ("1" + moving + "-2" + moving2);
		/*if (newRotValue != currentRotValue && !rotating) {
			currentRotValue = newRotValue;
			StartCoroutine(Rotate(currentRotValue, bult01));
			rotating = true;
		}*/
		//Debug.Log (rotating);
	}

	IEnumerator Rotate(float rotation, GameObject bult)
	{
		//Debug.Log(Vector3.Distance(v3ToRot, v3CurrentRot));
		Vector3 v3ToRot = new Vector3 (bult.transform.rotation.eulerAngles.x, bult.transform.rotation.eulerAngles.y, rotation);
		Vector3 v3CurrentRot = bult.transform.rotation.eulerAngles;
		while(Vector3.Distance(v3ToRot, v3CurrentRot) > 0.05f)
		{
			v3CurrentRot = Vector3.Lerp(v3CurrentRot, v3ToRot, Time.deltaTime * speedRot);
			bult.transform.eulerAngles = v3CurrentRot; 
			yield return null;
		}
		//rotating = false;
	}

	IEnumerator Expand(float size, GameObject bult)
	{
		//Debug.Log(Vector3.Distance(v3ToEx, v3CurrentEx));
		Vector3 v3ToEx = new Vector3 (bult.transform.localScale.x, size, bult.transform.localScale.z);
		Vector3 v3CurrentEx = bult.transform.localScale;
		while (Vector3.Distance(v3ToEx, v3CurrentEx) > 0.05f) {
			v3CurrentEx = Vector3.Lerp (v3CurrentEx, v3ToEx, Time.deltaTime * speedEx);
			bult.transform.localScale = v3CurrentEx; 
			yield return new WaitForFixedUpdate();
		}
		//expanding = false;
		//expanding2 = false;
	}

	IEnumerator MoveUpDown(float position, GameObject bult)
	{
		moving = true;
		Vector3 v3ToMove = new Vector3 (bult.transform.position.x, position, bult.transform.position.z);
		Vector3 v3CurrentMove = bult.transform.position;
		while (Vector3.Distance(v3ToMove, v3CurrentMove) > 0.005f) {
			bult.GetComponent<Rigidbody> ().MovePosition (v3ToMove);
			yield return new WaitForFixedUpdate();
		}
		moving = false;

		//Vector3 moveVector = new Vector3 (bult.transform.position.x, position, bult.transform.position.z);
		//bult.GetComponent<Rigidbody> ().MovePosition (moveVector);
	}

	IEnumerator MoveUpDown2(float position, GameObject bult)
	{
		moving2 = true;
		Vector3 v3ToMove = new Vector3 (bult.transform.position.x, position, bult.transform.position.z);
		Vector3 v3CurrentMove = bult.transform.position;
		while (Vector3.Distance(v3ToMove, v3CurrentMove) > 0.005f) {
			bult.GetComponent<Rigidbody> ().MovePosition (v3ToMove);
			yield return new WaitForFixedUpdate();
		}
		moving2 = false;
		
		//Vector3 moveVector = new Vector3 (bult.transform.position.x, position, bult.transform.position.z);
		//bult.GetComponent<Rigidbody> ().MovePosition (moveVector);
	}

	IEnumerator MoveUpDown3(float position, GameObject bult)
	{
		moving3 = true;
		Vector3 v3ToMove = new Vector3 (bult.transform.position.x, position, bult.transform.position.z);
		Vector3 v3CurrentMove = bult.transform.position;
		while (Vector3.Distance(v3ToMove, v3CurrentMove) > 0.005f) {
			bult.GetComponent<Rigidbody> ().MovePosition (v3ToMove);
			yield return new WaitForFixedUpdate();
		}
		moving3 = false;
		
		//Vector3 moveVector = new Vector3 (bult.transform.position.x, position, bult.transform.position.z);
		//bult.GetComponent<Rigidbody> ().MovePosition (moveVector);
	}
	
	IEnumerator MoveUpDown4(float position, GameObject bult)
	{
		moving4 = true;
		Vector3 v3ToMove = new Vector3 (bult.transform.position.x, position, bult.transform.position.z);
		Vector3 v3CurrentMove = bult.transform.position;
		while (Vector3.Distance(v3ToMove, v3CurrentMove) > 0.005f) {
			bult.GetComponent<Rigidbody> ().MovePosition (v3ToMove);
			yield return new WaitForFixedUpdate();
		}
		moving4 = false;
		
		//Vector3 moveVector = new Vector3 (bult.transform.position.x, position, bult.transform.position.z);
		//bult.GetComponent<Rigidbody> ().MovePosition (moveVector);
	}
}
