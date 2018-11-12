using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicBehavior : MonoBehaviour
{
	public bool AudioBegin = false;

	private AudioSource _menuMusic;

	public void Awake()
	{
		_menuMusic = GetComponent<AudioSource>();
		if (GameObject.Find ("$MenuMusic").GetComponent<MenuMusicBehavior> ().AudioBegin == true)
			Destroy (gameObject);
		if (!AudioBegin && _menuMusic.enabled == true)
		{
			_menuMusic.Play();
			DontDestroyOnLoad(gameObject);
			AudioBegin = true;
		}
	}

	public void StopMusic()
	{
		_menuMusic.Stop();
		AudioBegin = false;
		//Destroy(gameObject);
	}
}
