using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenBehavior : MonoBehaviour
{
	void Start()
	{
		SceneManager.LoadScene("00-StartMenu");
	}
}
