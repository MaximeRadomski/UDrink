using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetReadyBehavior : MonoBehaviour
{
	private AudioSource _click;
	private GameObject _timerNumber;
	private int _timerValue;
	private string _nextSceneName;
	private List<string> TitlesNames = new List<string>{ "Title01", "Title02", "SlowTitle01", "SlowTitle02" };

	void Start()
	{
		_click = this.GetComponent<AudioSource>();
		_timerNumber = GameObject.Find ("TimerNumber");
		_timerValue = 3;
		var randomSceneNumber = PlayerPrefs.GetInt ("RandomSceneNumber");
		var tmpScene = (ScenesEnum)randomSceneNumber;
		var tmpSceneName = tmpScene.ToString ();
		var tmpSceneUpperName = tmpSceneName.Replace ("0", " ");
		tmpSceneName = tmpSceneName.Replace ("0", "");
		DisplaySceneNameInTitles(tmpSceneUpperName.ToUpper());
		_nextSceneName = randomSceneNumber.ToString ("D3") + "-" + tmpSceneName;
		Invoke("DecreaseTimerNumber", 1.0f);
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
		--_timerValue;
		_click.Play ();
		if (_timerValue > 0)
		{
			_timerNumber.GetComponent<UnityEngine.UI.Text> ().text = _timerValue.ToString ();
			Invoke("DecreaseTimerNumber", 1.0f);
		}
		else
		{
			_timerNumber.GetComponent<UnityEngine.UI.Text> ().text = "GO!";
			Invoke("GoToNextScene", 0.5f);
		}
	}

	private void GoToNextScene()
	{
		SceneManager.LoadScene(_nextSceneName);
	}
}
