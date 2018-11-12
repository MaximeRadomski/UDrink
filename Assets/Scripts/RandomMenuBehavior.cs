using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class RandomMenuBehavior : MonoBehaviour
{
	private AudioSource _click;
	private GameObject _playerNumber;
	private GameObject _thatsSad;
	private GameObject _theAnswer;
	private int _nbPlayer;
	private int _nbScenes;

	void Start()
	{
		_click = this.GetComponent<AudioSource>();
		_nbPlayer = 2;
		_nbScenes = Enum.GetNames(typeof(ScenesEnum)).Length;
		_playerNumber = GameObject.Find("PlayerNumber");
		_thatsSad = GameObject.Find("ThatsSad");
		_theAnswer = GameObject.Find("TheAnswer");
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			GotoMainMenu();
		}
	}

	public void IncreaseNbPlayer()
	{
		if (_nbPlayer + 1 > 42)
			return;
		if (_nbPlayer + 1 > 1)
			_thatsSad.GetComponent<UnityEngine.UI.Text>().enabled = false;
		if (_nbPlayer + 1 == 42)
			_theAnswer.GetComponent<UnityEngine.UI.Text>().enabled = true;
		_click.Play();
		++_nbPlayer;
		_playerNumber.GetComponent<UnityEngine.UI.Text>().text = _nbPlayer.ToString();
	}

	public void DecreaseNbPlayer()
	{
		if (_nbPlayer - 1 < 1)
			return;
		if (_nbPlayer - 1 == 1)
			_thatsSad.GetComponent<UnityEngine.UI.Text>().enabled = true;
		if (_nbPlayer - 1 < 42)
			_theAnswer.GetComponent<UnityEngine.UI.Text>().enabled = false;
		_click.Play();
		--_nbPlayer;
		_playerNumber.GetComponent<UnityEngine.UI.Text>().text = _nbPlayer.ToString();
	}

	public void GotoMainMenu()
	{
		_click.Play();
		DontDestroyOnLoad(gameObject);
		Invoke("DestroyAfterListeningClick", 0.5f);
		SceneManager.LoadScene("01-MainMenu");
	}

	public void GoToNextScene()
	{
		_click.Play();
		DontDestroyOnLoad(gameObject);
		var randomSceneNumber = UnityEngine.Random.Range (1, _nbScenes);
		PlayerPrefs.SetInt ("RandomSceneNumber", randomSceneNumber);
		PlayerPrefs.SetInt ("PlayersNumber", _nbPlayer);
		Invoke("DestroyAfterListeningClick", 0.5f);
		SceneManager.LoadScene("03-GetReady");
	}

	private void DestroyAfterListeningClick()
	{
		Destroy(gameObject);
	}
}
