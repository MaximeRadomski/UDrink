using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
	private AudioSource _click;
	private List<string> TitlesNames = new List<string>{ "GameTitle01", "GameTitle02" };

	void Start()
	{
		_click = this.GetComponent<AudioSource>();
		var randomSceneNumber = PlayerPrefs.GetInt ("RandomSceneNumber");
		var tmpScene = (ScenesEnum)randomSceneNumber;
		var tmpSceneName = tmpScene.ToString ();
		var tmpSceneUpperName = tmpSceneName.Replace ("0", " ");
		DisplaySceneNameInTitles(tmpSceneUpperName.ToUpper());
	}

	private void DisplaySceneNameInTitles(string sceneUpperName)
	{
		GameObject.Find (TitlesNames[0]).GetComponent<UnityEngine.UI.Text> ().text = sceneUpperName;
		GameObject.Find (TitlesNames[1]).GetComponent<UnityEngine.UI.Text> ().text = sceneUpperName;
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

	private void DestroyAfterListeningClick()
	{
		Destroy(gameObject);
	}
}
