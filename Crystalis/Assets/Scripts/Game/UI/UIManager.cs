using LeoDeg.Managers;
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
        public Text gameOverTitle;
        public Text gameWinTitle;

        [Header ("Wave UI References")]
        public RectTransform newWaveBanner;
        public Text newWaveTitle;
        public Text newWaveEnemyCount;

        [Header ("Game UI References")]
        public Text scoreText;
        public Text gameOverScoreText;
        public Text healthText;
        public Text waveText;
        public Text enemiesText;

        private bool gameWin;

        private void Awake ()
        {
            spawner = FindObjectOfType<SpawnManager> ();
            spawner.OnNewWave += OnNewWave;
        }

        public void Start ()
        {
            Cursor.visible = false;
            gameWin = false;
            playerStateMachine.value.OnDeath.AddListener (OnGameOver);
        }

        private void Update ()
        {
            scoreText.text = string.Format ("Kills: {0}", playerStateMachine.value.statsProperties.GetScore ().ToString ());
            healthText.text = string.Format ("Health: {0}", playerStateMachine.value.statsProperties.GetHealth ().ToString ());
            waveText.text = string.Format ("Wave: {0}/{1}", spawner.GetWaveCount (), spawner.GetTotalWaveCount ());
            enemiesText.text = string.Format ("Enemies: {0}/{1}", spawner.GetAliveEnemyCount (), spawner.GetTotalEnemiesCount ());
        }

        private void LateUpdate ()
        {
            if (spawner.GetWaveCount () == spawner.GetTotalWaveCount () && spawner.GetAliveEnemyCount () == 0)
            {
                gameWin = true;
                OnGameOver ();
            }
        }

        private void OnNewWave (int waveNumber)
        {
            playerStateMachine.value.statsProperties.AddHealth (20);

            newWaveTitle.text = "Wave " + waveNumber.ToString ();

            string enemyCountString = spawner.waves[waveNumber - 1].infiniteWaves ? "Infinite"
                : spawner.waves[waveNumber - 1].spawnCount.ToString ();
            newWaveEnemyCount.text = "Enemies: " + enemyCountString;

            StopCoroutine (AnimateNewWaveBanner ());
            StartCoroutine (AnimateNewWaveBanner ());
        }

        private void OnGameOver ()
        {
            Cursor.visible = true;
            StartCoroutine (Fade (Color.clear, new Color (0, 0, 0, .95f), 1));


            healthText.transform.parent.gameObject.SetActive (false);
            scoreText.transform.parent.gameObject.SetActive (false);
            waveText.transform.parent.gameObject.SetActive (false);
            enemiesText.transform.parent.gameObject.SetActive (false);

            gameOverScoreText.text = scoreText.text;
            gameOverScreen.SetActive (true);


            gameWinTitle.gameObject.SetActive (gameWin);
            gameOverTitle.gameObject.SetActive (!gameWin);

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

        private IEnumerator AnimateNewWaveBanner ()
        {
            float delayTime = 3f;
            float speed = 2.5f;
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
