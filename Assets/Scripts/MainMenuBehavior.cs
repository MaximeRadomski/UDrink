using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehavior : MonoBehaviour
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
			GotoStartMenu();
		}
	}

	public void GotoStartMenu()
	{
		_click.Play();
		DontDestroyOnLoad(gameObject);
		Invoke("DestroyAfterListeningClick", 0.5f);
		SceneManager.LoadScene("00-StartMenu");
	}

	public void GotoSelectedScene(string sceneName)
	{
		_click.Play();
		DontDestroyOnLoad(gameObject);
		Invoke("DestroyAfterListeningClick", 0.5f);
		SceneManager.LoadScene(sceneName);
	}

	private void DestroyAfterListeningClick()
	{
		Destroy(gameObject);
	}
}
