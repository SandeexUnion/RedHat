using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public Transform layerTransform;
        public float parallaxSpeed;
        [HideInInspector] public Vector3 startPosition;
        [HideInInspector] public float textureUnitSizeX;
    }

    [Header("Main Settings")]
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private ParallaxLayer[] layers;
    [SerializeField] private bool infiniteHorizontal = true;

    private Vector3 lastCameraPosition;

    private void Start()
    {
        lastCameraPosition = cameraTransform.position;

        // Инициализация слоев
        for (int i = 0; i < layers.Length; i++)
        {
            layers[i].startPosition = layers[i].layerTransform.position;

            if (infiniteHorizontal)
            {
                Sprite sprite = layers[i].layerTransform.GetComponent<SpriteRenderer>().sprite;
                layers[i].textureUnitSizeX = sprite.texture.width / sprite.pixelsPerUnit;
            }
        }
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

        for (int i = 0; i < layers.Length; i++)
        {
            // Параллакс-движение
            Vector3 parallaxPosition = layers[i].startPosition +
                                      new Vector3(deltaMovement.x * layers[i].parallaxSpeed, 0, 0);
            layers[i].layerTransform.position = new Vector3(parallaxPosition.x, layers[i].startPosition.y, layers[i].startPosition.z);

            // Бесконечный повтор текстуры
            if (infiniteHorizontal)
            {
                float offsetPosX = (cameraTransform.position.x - layers[i].layerTransform.position.x) % layers[i].textureUnitSizeX;
                if (Mathf.Abs(cameraTransform.position.x - layers[i].layerTransform.position.x) >= layers[i].textureUnitSizeX)
                {
                    layers[i].layerTransform.position = new Vector3(
                        cameraTransform.position.x + offsetPosX,
                        layers[i].layerTransform.position.y);
                }
            }
        }

        lastCameraPosition = cameraTransform.position;
    }
}