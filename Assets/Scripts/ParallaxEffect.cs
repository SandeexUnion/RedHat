using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] Material mat;
    [SerializeField] float distance;

    [Range(0f, 0.5f)] 
    public float speed = 0.2f;
    

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        distance += Time.deltaTime * speed;
        mat.SetTextureOffset("_MainTex", Vector2.right * distance);
    }
        
}