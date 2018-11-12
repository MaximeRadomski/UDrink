using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMenuTapItem : MonoBehaviour
{
	public GenericTapAction Action;

	private GameObject _randomManager;

	void Start ()
	{
		_randomManager = GameObject.Find("$RandomMenuManager");
	}

	void OnMouseDown()
	{
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, 0.75f);
	}

	void OnMouseUp()
	{
		switch (Action)
		{
		case GenericTapAction.Increase:
			_randomManager.GetComponent<RandomMenuBehavior>().IncreaseNbPlayer();
			break;
		case GenericTapAction.Decrease:
			_randomManager.GetComponent<RandomMenuBehavior>().DecreaseNbPlayer();
			break;
		}
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
	}

	public enum GenericTapAction
	{
		Increase,
		Decrease
	}
}
