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
			if (!LoadManager.GameSavedFileExists()) return;
			
			GameManager.LoadData = new LoadData(LoadManager.GetGameSavedFile(), LoadType.LoadGame);
			ChangeScene(level);
		}

		public void NewGame(string level)
		{
			GameManager.LoadData = new LoadData();
			ChangeScene(level);
		}

		public void GoBackToMenu(string level)
		{
			_loadManager.SaveGame();
			ChangeScene(level);
		}
	}
}