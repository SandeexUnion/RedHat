using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private int baseDamage = 1;
    private float damageMultiplier = 1f;

    public void SetDamageMultiplier(float multiplier)
    {
        damageMultiplier = multiplier;
    }

    public void Attack(GameObject target)
    {
        //var health = target.GetComponent<Health>();
        //if (health != null)
        {
           // health.TakeDamage(Mathf.RoundToInt(baseDamage * damageMultiplier));
        }
    }
}