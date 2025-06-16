using UnityEngine;

public class WolfAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private int damage = 15;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float pushForce;

    [Header("Debug")]
    [SerializeField] private bool drawGizmos = true;
    [SerializeField] private Color gizmoColor = Color.red;

    private float lastAttackTime;
    private bool canAttack = true;

    public void StartAttack()
    {
        if (!canAttack || Time.time - lastAttackTime < attackCooldown) return;

        PerformAttack();
        lastAttackTime = Time.time;
        canAttack = false;
        Invoke(nameof(ResetAttack), attackCooldown);
    }

    private void PerformAttack()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach (Collider2D player in hitPlayers)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            PlayerHealth health = player.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamageWithPush(damage, direction, pushForce);
                Debug.Log($"Wolf attacked {player.name} for {damage} damage!");
            }
        }
    }

    private void ResetAttack() => canAttack = true;

    public void StopAttack()
    {
        CancelInvoke(nameof(ResetAttack));
        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (!drawGizmos || attackPoint == null) return;

        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawLine(attackPoint.position, attackPoint.position + transform.right * attackRange);
    }
}