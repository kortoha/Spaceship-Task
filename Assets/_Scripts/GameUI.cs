using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _damageCountText;

    [SerializeField] private DamageManager _damageManager;

    [SerializeField] private ObstaclesSpawner _obstaclesSpawner;

    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _startPanel;

    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _startButton;

    private void Start()
    {
        _damageManager.OnDamageTaken += OnDamageTaken;

        _pauseButton.onClick.AddListener(OpenPauseMenu);
        _resumeButton.onClick.AddListener(ResumeGame);
        _restartButton.onClick.AddListener(RestartGame);
        _startButton.onClick.AddListener(StartGame);
        _exitButton.onClick.AddListener( () =>
        {
            SoundController.Instance.PlayClickSound();
            Application.Quit();
        });
    }

    private void OnDamageTaken(int damageCount)
    {
        damageCount++;
        _damageCountText.text = damageCount.ToString();
    }

    private void StartGame()
    {
        SoundController.Instance.PlayClickSound();
        _startPanel.SetActive(false);
        _gamePanel.SetActive(true);
        _obstaclesSpawner.SetIsCanSpawn(true);
    }

    private void OpenPauseMenu()
    {
        SoundController.Instance.PlayClickSound();
        _gamePanel.SetActive(false);
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void RestartGame()
    {
        SoundController.Instance.PlayClickSound();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    private void ResumeGame()
    {
        SoundController.Instance.PlayClickSound();
        _gamePanel.SetActive(true);
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnDisable()
    {
        _damageManager.OnDamageTaken -= OnDamageTaken;
    }
}
