using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetPlayerReadyBehavior : MonoBehaviour
{
	private string _nextSceneName;
	private List<string> TitlesNames = new List<string>{ "Title01", "Title02" };
	private int _currentPlayer;

	void Start()
	{
		var randomSceneNumber = PlayerPrefs.GetInt ("RandomSceneNumber");
		var tmpScene = (ScenesEnum)randomSceneNumber;
		var tmpSceneName = tmpScene.ToString ();
		tmpSceneName = tmpSceneName.Replace ("0", "");
		_nextSceneName = randomSceneNumber.ToString ("D3") + "-" + tmpSceneName;
		_currentPlayer = PlayerPrefs.GetInt("CurrentPlayer");
		DisplaySceneNameInTitles ();
		Invoke ("GotoNextScene", 2.0f);
	}

	private void DisplaySceneNameInTitles()
	{
		var tmpPlayer = GameObject.Find (TitlesNames [0]);
		if (tmpPlayer != null)
			tmpPlayer.GetComponent<UnityEngine.UI.Text> ().text = "PLAYER " + _currentPlayer;
		tmpPlayer = GameObject.Find (TitlesNames [1]);
		if (tmpPlayer != null)
			tmpPlayer.GetComponent<UnityEngine.UI.Text> ().text = "PLAYER " + _currentPlayer;
	}
	
	private void GotoNextScene()
	{
		SceneManager.LoadScene(_nextSceneName);
	}
}
