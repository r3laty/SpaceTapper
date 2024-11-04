using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    public bool NextPlanet { get; set; }
    [SerializeField] private Transform pivot;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float strengthMultiplier = 3;
    private List<Rigidbody2D> _affectedBodies = new List<Rigidbody2D>();

    private void Update()
    {
        Debug.Log($"Update {_affectedBodies.Count}");

        if (_affectedBodies.Count > 0)
        {
            foreach (Rigidbody2D body in _affectedBodies.ToList())
            {
                if (body.CompareTag(CompareTags.Player))
                {
                    pivot.position = body.position;
                    Vector2 position = transform.position;
                    Vector2 direction = (position - body.position).normalized;
                    float distance = (position - body.position).magnitude;
                    float strength = strengthMultiplier * body.mass * rb.mass / distance;

                    body.AddForce(direction * strength);

                    if (distance < 1)
                    {
                        body.transform.SetParent(transform);
                        body.position = pivot.position;
                        body.GetComponent<Constraint>().enabled = true;
                        body.linearVelocity = Vector2.zero;
                        _affectedBodies.Remove(body);
                        MessageAboutNextPlanet.Instance.NextPlanetEvent();
                    }
                }
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Rigidbody2D rb) && other.CompareTag(CompareTags.Player))
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
