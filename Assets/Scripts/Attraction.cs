using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    private Rigidbody2D _rb;
    private List<Rigidbody2D> _affectedBodies = new List<Rigidbody2D>();

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        Debug.Log(pivot.name);
    }

    private void Update()
    {
        if (_affectedBodies.Count == 0)
        {
            return;
        }

        foreach (Rigidbody2D body in _affectedBodies.ToList())
        {
            Vector2 position = transform.position;
            Vector2 direction = (position - body.position).normalized;  
            float distance = (position - body.position).magnitude;
            float strength = body.mass * _rb.mass / distance;

            body.AddForce(direction * strength);

            if (distance < 1)
            {
                body.position = pivot.position;
                body.GetComponent<Constraint>().enabled = true;
                body.linearVelocity = Vector2.zero;
                _affectedBodies.Remove(body);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Rigidbody2D rb))
        {
            Debug.Log("Trigger enter + " + rb.name);
            _affectedBodies.Add(rb);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Rigidbody2D rb))
        {
            if (_affectedBodies != null && _affectedBodies.Contains(rb))
            {
                _affectedBodies.Remove(rb);
            }
        }
    }
}
