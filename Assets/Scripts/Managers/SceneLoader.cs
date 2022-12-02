using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR 
using UnityEditor;
#endif

namespace Game.Managers
{
	public class SceneLoader : MonoBehaviour
	{
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
	}
}