using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LeoDeg.Managers
{
    public class MusicManager : MonoBehaviour
    {
        public AudioClip gameMusic;
        public AudioClip menuMusic;
        private string sceneName;

        private void Start ()
        {
            PlayMainMusic ();
        }

        public void PlayMainMusic ()
        {
            AudioManager.Instance.PlayMusic (gameMusic, 2);
        }

        public void PlayMenuMusic ()
        {
            AudioManager.Instance.PlayMusic (menuMusic, 2);
        }
    }
}