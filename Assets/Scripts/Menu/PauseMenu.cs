using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private string mainMenuScene = "MainMenu";

    private bool isPaused = false;

    void Update()
    {
        // Альтернативное управление через клавишу ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void TogglePause()
    {
        if (isPaused)
            Resume();
        else
            Pause();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f; // Останавливаем время в игре
        isPaused = true;

        // Дополнительно: отключаем звуки игры
        AudioListener.pause = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f; // Возобновляем время
        isPaused = false;

        // Включаем звуки обратно
        AudioListener.pause = false;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Важно сбросить timescale перед загрузкой сцены!
        SceneManager.LoadScene(mainMenuScene);
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}