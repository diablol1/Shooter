using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour {

	public float leftTime;

	public int GetInSeconds() {
		return Mathf.RoundToInt (leftTime);
	}

	void Update() {
		if(Mathf.Sign(leftTime - Time.deltaTime) == -1) //Is negative?
			leftTime = 0;
		
		if(leftTime != 0) 
			leftTime -= Time.deltaTime;
	}
}
