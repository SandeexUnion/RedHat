using UnityEngine;

public abstract class InteractItem : MonoBehaviour
{
    [Header("Base Item Settings")]
    [SerializeField] private string itemName;
    [SerializeField] private Sprite icon;
    [SerializeField] private int maxStack = 1; // Максимальное количество в стаке

    public string ItemName => itemName;
    public Sprite Icon => icon;
    public int MaxStack => maxStack;

    // Абстрактный метод использования предмета
    public abstract void Use(PlayerInput player);

    // Метод, вызываемый при подборе предмета
    public virtual void OnPickup()
    {
        gameObject.SetActive(false);
    }

    // Метод, вызываемый при выбросе предмета
    public virtual void OnDrop()
    {
        gameObject.SetActive(true);
    }
}