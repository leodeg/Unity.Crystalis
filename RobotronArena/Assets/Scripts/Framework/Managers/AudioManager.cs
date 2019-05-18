using System.Collections;
using UnityEngine;

namespace LeoDeg.Managers
{
    public class AudioManager : MonoBehaviour
    {
        public enum AudioChannel { Master, Sfx, Music };

        public Scriptables.FloatScriptable deltaTime;
        public Scriptables.TransformScriptable playerTransform;

        public static AudioManager Instance;
        public bool isPlaying;

        public float masterVolume = 0.2f;
        public float sfxVolume = 1f;
        public float musicVolume = 0.4f;

        private AudioSource sfx2DSource;
        private AudioSource musicSources;
        private SoundLibrary library;
        private int activeMusicIndex;
        private Transform audioListener;

        private void Awake ()
        {
            if (Instance != null)
                Destroy (this.gameObject);

            Instance = this;
            //DontDestroyOnLoad (gameObject);

            audioListener = FindObjectOfType<AudioListener> ().transform;
            library = GetComponent<SoundLibrary> ();
            musicSources = new AudioSource ();
            sfx2DSource = new AudioSource ();

            GameObject newMusicSource = new GameObject ("MusicSource");
            musicSources = newMusicSource.AddComponent<AudioSource> ();
            newMusicSource.transform.parent = this.transform;

            GameObject newSfxSource = new GameObject ("SfxSource");
            sfx2DSource = newSfxSource.AddComponent<AudioSource> ();
            sfx2DSource.transform.parent = this.transform;
        }

        private void Update ()
        {
            if (playerTransform.value != null)
            {
                audioListener.position = playerTransform.value.position;
            }
        }

        public void PlayMusic (AudioClip music, float fadeDuration = 1)
        {
            if (musicSources.clip != null)
                musicSources.Stop ();

            if (music != null)
            {
                musicSources.clip = music;
                musicSources.loop = true;
                musicSources.Play ();
                musicSources.volume = musicVolume;
                Debug.Log ("AudioManager:PlayMusic: is playing " + musicSources.isPlaying);
            }
            else
            {
                Debug.LogWarning ("AudioManager:PlayMusic: Music is null!");
            }

        }

        public void PlaySound (AudioClip sound, Vector3 position)
        {
            if (sound != null)
                AudioSource.PlayClipAtPoint (sound, position, sfxVolume * masterVolume);
            else Debug.LogWarning ("AudioManager:PlaySound: Sound is null!");

            Debug.Log ("AudioManager:PlaySound");
        }

        public void PlaySound2D (AudioClip sound)
        {
            sfx2DSource.PlayOneShot (sound, sfxVolume * masterVolume);
        }


        public void SetVolume (float volumePercent, AudioChannel channel)
        {
            switch (channel)
            {
                case AudioChannel.Master:
                    masterVolume = volumePercent;
                    break;
                case AudioChannel.Sfx:
                    sfxVolume = volumePercent;
                    break;
                case AudioChannel.Music:
                    musicVolume = volumePercent;
                    break;
            }

            musicSources.volume = musicVolume * masterVolume;

            PlayerPrefs.SetFloat ("master vol", masterVolume);
            PlayerPrefs.SetFloat ("sfx vol", sfxVolume);
            PlayerPrefs.SetFloat ("music vol", musicVolume);
            PlayerPrefs.Save ();
        }
    }
}
