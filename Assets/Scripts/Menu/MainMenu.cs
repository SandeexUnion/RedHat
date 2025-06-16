using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // ����� ��� ������ "������"
    public void PlayGame()
    {
        SceneManager.LoadScene(1); // ��������� ����� � �������� 1 (GameScene)
    }

    // ����� ��� ������ "�����"
    public void QuitGame()
    {
        Application.Quit(); // ��������� ����������

        // � ��������� Unity ��� �� ���������, ������� ������� ���
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}