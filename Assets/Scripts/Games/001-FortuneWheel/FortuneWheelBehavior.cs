using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortuneWheelBehavior : MonoBehaviour
{
	public bool IsSpinning;

 	private GameObject _fortuneWheel; 

	void Start ()
	{
		IsSpinning = true;
		_fortuneWheel = GameObject.Find("FortuneWheel");
		Invoke ("TimesUp", 3.0f);
	}

	void Update ()
	{
		if (IsSpinning)
			_fortuneWheel.transform.Rotate(0,0,_fortuneWheel.transform.rotation.z + 7.0f);
	}

	private void TimesUp()
	{
		if (!IsSpinning)
			return;
		IsSpinning = false;
		_fortuneWheel.GetComponent<BoxCollider2D> ().enabled = false;
		_fortuneWheel.transform.rotation = new Quaternion ();
		_fortuneWheel.transform.Rotate (0,0,5.0f);
	}
}
