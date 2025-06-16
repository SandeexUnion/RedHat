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
        // Получаем размер экрана в мировых координатах
        float screenHeight = mainCamera.orthographicSize * 2f;
        float screenWidth = screenHeight * mainCamera.aspect;

        // Масштабируем Plane под размер экрана
        transform.localScale = new Vector3(
            screenWidth / 10f,  // Plane по умолчанию 10x10 единиц
            1f,
            screenHeight / 10f
        );

        // Позиционируем фон за камерой (но в пределах видимости)
        transform.position = new Vector3(
            mainCamera.transform.position.x,
            mainCamera.transform.position.y,
            transform.position.z // Сохраняем исходную Z-позицию
        );
    }
}