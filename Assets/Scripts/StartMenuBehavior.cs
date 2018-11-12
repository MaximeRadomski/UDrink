using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuBehavior : MonoBehaviour
{
	private AudioSource _click;

	void Start()
	{
		_click = this.GetComponent<AudioSource>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			_click.Play();
			Application.Quit();
		}
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
