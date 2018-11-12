using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomMenuBehavior : MonoBehaviour
{
	private AudioSource _click;
	private int _nbPlayer;
	private GameObject PlayerNumber;
	private GameObject ThatsSad;

	void Start()
	{
		_click = this.GetComponent<AudioSource>();
		_nbPlayer = 2;
		PlayerNumber = GameObject.Find("PlayerNumber");
		ThatsSad = GameObject.Find("ThatsSad");
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
			ThatsSad.GetComponent<UnityEngine.UI.Text> ().enabled = false;
		_click.Play();
		++_nbPlayer;
		PlayerNumber.GetComponent<UnityEngine.UI.Text>().text = _nbPlayer.ToString();
	}

	public void DecreaseNbPlayer()
	{
		if (_nbPlayer - 1 < 1)
			return;
		if (_nbPlayer - 1 < 2)
			ThatsSad.GetComponent<UnityEngine.UI.Text> ().enabled = true;
		_click.Play();
		--_nbPlayer;
		PlayerNumber.GetComponent<UnityEngine.UI.Text>().text = _nbPlayer.ToString();
	}

	public void GotoMainMenu()
	{
		_click.Play();
		DontDestroyOnLoad(gameObject);
		Invoke("DestroyAfterListeningClick", 0.5f);
		SceneManager.LoadScene("01-MainMenu");
	}

	private void DestroyAfterListeningClick()
	{
		Destroy(gameObject);
	}
}
