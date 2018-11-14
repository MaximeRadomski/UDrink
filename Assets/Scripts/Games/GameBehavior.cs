using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameBehavior : MonoBehaviour
{
	public bool CanDecreaseTimer = true;

	private AudioSource _click;
	private List<string> TitlesNames = new List<string>{ "GameTitle01", "GameTitle02", "Player01", "Player02" };
	private GameObject _timerNumber01, _timerNumber02;
	private int _currentPlayer;
	private int _timerValue;

	void Start()
	{
		_click = this.GetComponent<AudioSource>();
		_currentPlayer = PlayerPrefs.GetInt("CurrentPlayer");
		_timerNumber01 = GameObject.Find ("TimerNumber01");
		_timerNumber02 = GameObject.Find ("TimerNumber02");
		_timerValue = 3;
		var randomSceneNumber = PlayerPrefs.GetInt ("RandomSceneNumber");
		var tmpScene = (ScenesEnum)randomSceneNumber;
		var tmpSceneName = tmpScene.ToString ();
		var tmpSceneUpperName = tmpSceneName.Replace ("0", " ");
		DisplaySceneNameInTitles(tmpSceneUpperName.ToUpper());
		Invoke("DecreaseTimerNumber", 1.0f);
	}

	private void DisplaySceneNameInTitles(string sceneUpperName)
	{
		GameObject.Find (TitlesNames[0]).GetComponent<UnityEngine.UI.Text> ().text = sceneUpperName;
		GameObject.Find (TitlesNames[1]).GetComponent<UnityEngine.UI.Text> ().text = sceneUpperName;
		var tmpPlayer = GameObject.Find (TitlesNames [2]);
		if (tmpPlayer != null)
			tmpPlayer.GetComponent<UnityEngine.UI.Text> ().text = "P" + _currentPlayer;
		tmpPlayer = GameObject.Find (TitlesNames [3]);
		if (tmpPlayer != null)
			tmpPlayer.GetComponent<UnityEngine.UI.Text> ().text = "P" + _currentPlayer;
	}

	private void DecreaseTimerNumber()
	{
		if (CanDecreaseTimer == false)
			return;
		--_timerValue;
		if (_timerValue > 0)
		{
			_timerNumber01.GetComponent<UnityEngine.UI.Text> ().text = _timerValue.ToString ();
			_timerNumber02.GetComponent<UnityEngine.UI.Text> ().text = _timerValue.ToString ();
			Invoke("DecreaseTimerNumber", 1.0f);
		}
		else
		{
			_timerNumber01.GetComponent<UnityEngine.UI.Text> ().text = "OVER";
			_timerNumber02.GetComponent<UnityEngine.UI.Text> ().text = "OVER";
			GameOver ("DRINK!");
			Invoke("ReloadOrGotoNextScene", 2.5f);
		}
	}

	public void GameOver(string message)
	{
		GameObject.Find ("$GameManager").GetComponent<GameBehavior> ().CanDecreaseTimer = false;
		GameObject.Find ("GameTitle01").GetComponent<UnityEngine.UI.Text> ().enabled = false;
		GameObject.Find ("GameTitle02").GetComponent<UnityEngine.UI.Text> ().enabled = false;
		GameObject.Find ("DRINK01").GetComponent<UnityEngine.UI.Text> ().enabled = true;
		GameObject.Find ("DRINK02").GetComponent<UnityEngine.UI.Text> ().enabled = true;
		GameObject.Find ("DRINK01").GetComponent<UnityEngine.UI.Text> ().text = message;
		GameObject.Find ("DRINK02").GetComponent<UnityEngine.UI.Text> ().text = message;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			GotoMainMenu();
		}
	}

	public void GotoMainMenu()
	{
		_click.Play();
		DontDestroyOnLoad(gameObject);
		Invoke("DestroyAfterListeningClick", 0.5f);
		SceneManager.LoadScene("01-MainMenu");
	}

	public void ReloadOrGotoNextScene()
	{
		++_currentPlayer;
		if (_currentPlayer > PlayerPrefs.GetInt ("PlayersNumber"))
		{
			GoToNextScene ();
			return;
		}
		PlayerPrefs.SetInt("CurrentPlayer", _currentPlayer);
		SceneManager.LoadScene("03-GetPlayerReady");
	}

	public void GoToNextScene()
	{
		DontDestroyOnLoad(gameObject);
		var randomSceneNumber = UnityEngine.Random.Range (1, Enum.GetNames(typeof(ScenesEnum)).Length);
		PlayerPrefs.SetInt ("RandomSceneNumber", randomSceneNumber);
		PlayerPrefs.SetInt("CurrentPlayer", 1);
		Invoke("DestroyAfterListeningClick", 0.5f);
		SceneManager.LoadScene("03-GetReady");
	}

	private void DestroyAfterListeningClick()
	{
		Destroy(gameObject);
	}
}
