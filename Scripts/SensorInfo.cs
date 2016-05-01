// Copyright (c) 2016 Yasuhide Okamoto
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a class to display a text about sensors' information. 
/// </summary>
[RequireComponent(typeof(Text))]
public class SensorInfo : MonoBehaviour {
	
	/// <summary>
	/// A GameObject whose rotation angles are monitored. 
	/// </summary>
	[SerializeField]
	GameObject targetObj;
	
	Text text;
	
	ChangeRotationMethod rmethod;

	void Start () {
		text = GetComponent<Text>();
		if(targetObj != null)
			rmethod = targetObj.GetComponent<ChangeRotationMethod>();
	}
	
	void Update () {
		text.text = 
		"Sensor Info\n" + 
		"location service:" + Input.location.status + "\n" +
		"location:" + Input.location.lastData.longitude + "," + Input.location.lastData.latitude + "\n" +
		"compass heading:true:" + Input.compass.trueHeading + " mag:" + Input.compass.magneticHeading + "\n" +
		"compass accuracy:" + Input.compass.headingAccuracy + "\n" +
		"rawVector:" + Input.compass.rawVector.ToString("F5") + "\n" +
		"gyro.attitude:" + Input.gyro.attitude.ToString("F5") + "\n" +
		"gravity:" + Input.gyro.gravity.ToString("F5") + "\n" +
		"orientation:Input:" + Input.deviceOrientation + " Screen:" + Screen.orientation +"\n" +
		"rotation method:" + (rmethod != null ? rmethod.CurrentRotateMethod.ToString() : "null") + "\n" +
		"rotation:" + targetObj.transform.localEulerAngles.ToString("F5") + "\n"
		;
	}
}
