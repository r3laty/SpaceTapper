using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private float gravityRadius = 3;
    [SerializeField] private float gravityForce = 10f;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, gravityRadius);
        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null && rb.gameObject != this.gameObject)
            {
                Vector2 position = transform.position;
                Vector2 direction = (transform.position - collider.transform.position).normalized;
                float distance = (position - rb.position).magnitude;
                float strength = gravityForce * rb.mass * _rb.mass / distance;
                rb.AddForce(direction * strength);
                if (distance < 1)
                {
                    rb.bodyType = RigidbodyType2D.Kinematic;
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, gravityRadius);
    }
}
