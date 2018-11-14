using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetReadyBehavior : MonoBehaviour
{
	public AudioSource Click01;
	public AudioSource Click02;

	private GameObject _timerNumber;
	private int _timerValue;
	private List<string> TitlesNames = new List<string>{ "Title01", "Title02", "SlowTitle01", "SlowTitle02" };
	private bool _timerSemiInterval = true;

	void Start()
	{
		Click01 = this.GetComponent<AudioSource>();
		_timerNumber = GameObject.Find ("TimerNumber");
		_timerValue = 3;
		var randomSceneNumber = PlayerPrefs.GetInt ("RandomSceneNumber");
		var tmpScene = (ScenesEnum)randomSceneNumber;
		var tmpSceneName = tmpScene.ToString ();
		var tmpSceneUpperName = tmpSceneName.Replace ("0", " ");
		DisplaySceneNameInTitles(tmpSceneUpperName.ToUpper());
		Invoke("DecreaseTimerNumber", 0.5f);
	}

	private void DisplaySceneNameInTitles(string sceneUpperName)
	{
		GameObject.Find (TitlesNames[0]).GetComponent<UnityEngine.UI.Text> ().text = sceneUpperName;
		GameObject.Find (TitlesNames[1]).GetComponent<UnityEngine.UI.Text> ().text = sceneUpperName;
		GameObject.Find (TitlesNames[2]).GetComponent<UnityEngine.UI.Text> ().text =
			sceneUpperName + " - " + sceneUpperName + " - " + sceneUpperName + " - " + sceneUpperName + " - " + 
			sceneUpperName + " - " + sceneUpperName + " - " + sceneUpperName + " - " + sceneUpperName;
		GameObject.Find (TitlesNames[3]).GetComponent<UnityEngine.UI.Text> ().text =
			sceneUpperName + " - " + sceneUpperName + " - " + sceneUpperName + " - " + sceneUpperName + " - " + 
			sceneUpperName + " - " + sceneUpperName + " - " + sceneUpperName + " - " + sceneUpperName;
	}

	private void DecreaseTimerNumber()
	{
		if (_timerSemiInterval)
		{
			_timerSemiInterval = false;
			Click02.Play ();
			Invoke("DecreaseTimerNumber", 0.5f);
			return;
		}
		--_timerValue;
		Click01.Play ();
		if (_timerValue > 0)
		{
			_timerNumber.GetComponent<UnityEngine.UI.Text> ().text = _timerValue.ToString ();
			_timerSemiInterval = true;
			Invoke("DecreaseTimerNumber", 0.5f);
		}
		else
		{
			_timerNumber.GetComponent<UnityEngine.UI.Text> ().text = "GO!";
			Invoke("GoToNextScene", 0.5f);
		}
	}

	private void GoToNextScene()
	{
		SceneManager.LoadScene("03-GetPlayerReady");
	}
}
