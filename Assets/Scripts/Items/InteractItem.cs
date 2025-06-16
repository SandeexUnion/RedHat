using UnityEngine;

public abstract class InteractItem : MonoBehaviour
{
    [Header("Base Item Settings")]
    [SerializeField] private string itemName;
    [SerializeField] private Sprite icon;
    [SerializeField] private int maxStack = 1; // ������������ ���������� � �����

    public string ItemName => itemName;
    public Sprite Icon => icon;
    public int MaxStack => maxStack;

    // ����������� ����� ������������� ��������
    public abstract void Use(PlayerInput player);

    // �����, ���������� ��� ������� ��������
    public virtual void OnPickup()
    {
        gameObject.SetActive(false);
    }

    // �����, ���������� ��� ������� ��������
    public virtual void OnDrop()
    {
        gameObject.SetActive(true);
    }
}