﻿using UnityEngine;

public class ChangeRotationMethod : MonoBehaviour {
	
	public enum RotateMethod
	{
		Gyro, 
		Compass, 
	}
	
	[SerializeField]
	RotateMethod rotateMethod = RotateMethod.Gyro;
	public RotateMethod CurrentRotateMethod
	{
		get { return rotateMethod; }
	}
	
	RotateWithGyro rgyro;
	RotateWithCompass rcompass;
	
	void SetRotateMethod()
	{
		if(rgyro != null)
			rgyro.enabled = (rotateMethod == RotateMethod.Gyro);
		if(rcompass != null)
			rcompass.enabled = (rotateMethod == RotateMethod.Compass);
	}

	void Start () {
		rgyro = GetComponent<RotateWithGyro>();
		rcompass = GetComponent<RotateWithCompass>();
		
		SetRotateMethod();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(0))
		{
			if(rotateMethod == RotateMethod.Gyro)
				rotateMethod = RotateMethod.Compass;
			else
				rotateMethod = RotateMethod.Gyro;
				
			SetRotateMethod();
		}
	}
}