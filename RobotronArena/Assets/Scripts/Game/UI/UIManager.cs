using LeoDeg.Enemies;
using LeoDeg.StateActions;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LeoDeg.UI
{
    internal class UIManager : MonoBehaviour
    {
        [Header ("Scenes names")]
        public string gameName = "Gameplay";
        public string menuName = "Menu";


        [Header ("Objects References")]
        public Scriptables.StateMachineScriptable playerStateMachine;
        public SpawnManager spawner;

        [Header ("UI References")]
        public Image fadeScreen;
        public GameObject gameOverScreen;

        [Header ("Wave UI References")]
        public RectTransform newWaveBanner;
        public Text newWaveTitle;
        public Text newWaveEnemyCount;

        [Header ("Game UI References")]
        public Text scoreText;
        public Text gameOverScoreText;
        public Text healthText;


        private void Awake ()
        {
            spawner.OnNewWave += OnNewWave;
        }

        public void Start ()
        {
            playerStateMachine.value.OnDeath.AddListener (OnGameOver);
        }

        private void Update ()
        {
            scoreText.text = string.Format("Score: {0}", playerStateMachine.value.statsProperties.GetScore().ToString ());
            healthText.text = string.Format("Health: {0}", playerStateMachine.value.statsProperties.GetHealth ().ToString ());
        }

        private void OnNewWave (int waveNumber)
        {
            string[] numbers = { "One", "Two", "Three", "Four", "Five" };
            newWaveTitle.text = "- Wave " + numbers[waveNumber - 1] + " -";

            string enemyCountString;

            if (spawner.waves[waveNumber - 1].infiniteWaves)
                enemyCountString = "Infinite";
            else enemyCountString = spawner.waves[waveNumber - 1].spawnCount + "";

            newWaveEnemyCount.text = "Enemies: " + enemyCountString;

            StopCoroutine ("AnimateNewWaveBanner");
            StartCoroutine ("AnimateNewWaveBanner");
        }

        private void OnGameOver ()
        {
            Cursor.visible = true;
            StartCoroutine (Fade (Color.clear, new Color (0, 0, 0, .95f), 1));

            healthText.transform.parent.gameObject.SetActive (false);
            scoreText.transform.parent.gameObject.SetActive (false);

            gameOverScoreText.text = scoreText.text;
            gameOverScreen.SetActive (true);
        }

        private IEnumerator Fade (Color from, Color to, float time)
        {
            float speed = 1 / time;
            float percent = 0;

            while (percent < 1)
            {
                percent += Time.deltaTime * speed;
                fadeScreen.color = Color.Lerp (from, to, percent);
                yield return null;
            }
        }

        IEnumerator AnimateNewWaveBanner ()
        {
            float delayTime = 1.5f;
            float speed = 3f;
            float animatePercent = 0;
            int dir = 1;

            float endDelayTime = Time.time + 1 / speed + delayTime;
            while (animatePercent >= 0)
            {
                animatePercent += Time.deltaTime * speed * dir;
                if (animatePercent >= 1)
                {
                    animatePercent = 1;
                    if (Time.time > endDelayTime)
                        dir = -1;
                }

                newWaveBanner.anchoredPosition = Vector2.up * Mathf.Lerp (-170, 45, animatePercent);
                yield return null;
            }

        }

        public void StartNewGame ()
        {
            SceneManager.LoadScene (gameName);
        }

        public void ReturnToMainMenu ()
        {
            SceneManager.LoadScene (menuName);
        }

        public void CloseGame ()
        {
            Application.Quit ();
        }
    }
}
