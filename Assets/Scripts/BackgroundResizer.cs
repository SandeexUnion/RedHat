using UnityEngine;

public class BackgroundResizer : MonoBehaviour
{
    private Camera mainCamera;
    private Renderer backgroundRenderer;

    void Start()
    {
        mainCamera = Camera.main;
        backgroundRenderer = GetComponent<Renderer>();
        ResizeBackground();
    }

    void ResizeBackground()
    {
        // �������� ������ ������ � ������� �����������
        float screenHeight = mainCamera.orthographicSize * 2f;
        float screenWidth = screenHeight * mainCamera.aspect;

        // ������������ Plane ��� ������ ������
        transform.localScale = new Vector3(
            screenWidth / 10f,  // Plane �� ��������� 10x10 ������
            1f,
            screenHeight / 10f
        );

        // ������������� ��� �� ������� (�� � �������� ���������)
        transform.position = new Vector3(
            mainCamera.transform.position.x,
            mainCamera.transform.position.y,
            transform.position.z // ��������� �������� Z-�������
        );
    }
}