using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FortuneWheelTapItem : MonoBehaviour
{
	private FortuneWheelBehavior _fortuneWheelBehavior;
	private GameObject _fortuneWheel;

	void Start ()
	{
		_fortuneWheelBehavior = GameObject.Find("$FortuneWheleManager").GetComponent<FortuneWheelBehavior>();
		_fortuneWheel = GameObject.Find("FortuneWheel");
	}

	void OnMouseDown()
	{
		_fortuneWheel.GetComponent<BoxCollider2D> ().enabled = false;
		for (int i = 0; i < _fortuneWheel.transform.childCount; ++i)
		{
			_fortuneWheel.transform.GetChild (i).GetComponent<PolygonCollider2D> ().enabled = true;
		}
		_fortuneWheelBehavior.IsSpinning = false;
		var tmpAudioSources = _fortuneWheel.GetComponents<AudioSource>();
		tmpAudioSources[0].Stop();
		tmpAudioSources[1].Play();
		Invoke ("ReloadScene", 2.5f);
	}

	private void ReloadScene()
	{
		GameObject.Find ("$GameManager").GetComponent<GameBehavior> ().ReloadOrGotoNextScene ();
	}
}
