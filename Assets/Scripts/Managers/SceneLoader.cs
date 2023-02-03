using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR 
using UnityEditor;
#endif



namespace Game.Managers
{
	public class SceneLoader : MonoBehaviour
	{
		[SerializeField] private LoadManager _loadManager;

		public void Exit()
		{
#if UNITY_EDITOR
			EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
		}

		public void ChangeScene(string level)
		{
			SceneManager.LoadScene(level);
			
		}
		public void ReloadScene()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		public void LoadGame(string level)
		{
			GameManager.loadType = LoadType.LoadGame;
			ChangeScene(level);

		}

		public void NewGame(string level)
		{
			GameManager.loadType = LoadType.NewGame;
			ChangeScene(level);
		}

		public void GoBackToMenu(string level)
		{
			_loadManager.SaveGame();
			ChangeScene(level);
		}
	}
}