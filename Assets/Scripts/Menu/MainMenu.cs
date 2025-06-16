using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Метод для кнопки "Играть"
    public void PlayGame()
    {
        SceneManager.LoadScene(1); // Загружаем сцену с индексом 1 (GameScene)
    }

    // Метод для кнопки "Выход"
    public void QuitGame()
    {
        Application.Quit(); // Закрываем приложение

        // В редакторе Unity это не сработает, поэтому выводим лог
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}