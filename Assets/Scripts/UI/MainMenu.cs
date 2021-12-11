using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public void Exit()
        {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
        }
        public void LoadLevel(int id)
        {
            SceneManager.LoadScene(id);
        }
    }
}
