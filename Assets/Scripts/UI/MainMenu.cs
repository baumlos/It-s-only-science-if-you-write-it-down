using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject[] deactivateOnStart;

        private void Start()
        {
            foreach (var o in deactivateOnStart)
            {
                o.SetActive(false);
            }
        }

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
