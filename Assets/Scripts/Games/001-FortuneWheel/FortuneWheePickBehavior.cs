using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortuneWheePickBehavior : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D col)
	{
		string tmpMessage = "";
		if (col.name == "FortuneWheel")
		{
			return;
		}
		else if (col.name.StartsWith("D"))
		{
			tmpMessage = "DRINK!";
		}
		else
		{
			tmpMessage = "PASS!";
		}
		GameObject.Find ("$GameManager").GetComponent<GameBehavior> ().GameOver (tmpMessage);
	}
}
