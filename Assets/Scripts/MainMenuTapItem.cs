using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuTapItem : MonoBehaviour
{
	public GenericTapAction Action;
	public string Parameter;

	private GameObject _mainMenuManager;

	void Start ()
	{
		_mainMenuManager = GameObject.Find("$MainMenuManager");
	}

	void OnMouseDown()
	{
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, 0.75f);
	}

	void OnMouseUp()
	{
		switch (Action)
		{
		case GenericTapAction.GoNextScene:
			_mainMenuManager.GetComponent<MainMenuBehavior>().GotoSelectedScene(Parameter);
			break;
		case GenericTapAction.GoPreviousScene:
			_mainMenuManager.GetComponent<MainMenuBehavior>().GotoStartMenu();
			break;
		}
	}

	public enum GenericTapAction
	{
		GoNextScene,
		GoPreviousScene
	}
}
