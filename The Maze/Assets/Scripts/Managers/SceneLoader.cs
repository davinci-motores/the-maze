using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
	public void Exit()
	{
		Application.Quit();
		Debug.Log("Game Exit");
	}

	public void ChangeScene(string level)
	{
		SceneManager.LoadScene(level);
		
	}
	public void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Debug.Log("Scene Reloaded");
	}
}
