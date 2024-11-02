using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    public bool NextPlanet { get; set; }
    [SerializeField] private Transform pivot;
    [SerializeField] private float strengthMultiplier = 3;
    private Rigidbody2D _rb;
    private List<Rigidbody2D> _affectedBodies = new List<Rigidbody2D>();

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_affectedBodies.Count == 0)
        {
            return;
        }

        foreach (Rigidbody2D body in _affectedBodies.ToList())
        {
            pivot.position = body.position;
            Vector2 position = transform.position;
            Vector2 direction = (position - body.position).normalized;  
            float distance = (position - body.position).magnitude;
            float strength = strengthMultiplier * body.mass * _rb.mass / distance;

            body.AddForce(direction * strength);

            if (distance < 1)
            {
                body.transform.SetParent(transform);
                body.position = pivot.position;
                body.GetComponent<Constraint>().enabled = true;
                body.linearVelocity = Vector2.zero;
                _affectedBodies.Remove(body);
                MessageAboutNextPlanet.Instance.SetNextPlanet(true);
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
