using System;
using UnityEngine;

public class AttractionTEST : MonoBehaviour
{
    private Collider2D _collider;
    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(CompareTags.Player))
        {
            Debug.Log("Trigger enter + " + other.name + " in " + name + " TESTING");
            GameObject player = other.gameObject;
            if (player.TryGetComponent(out Rigidbody2D rb))
            {
                Debug.Log("Rigidbody found");
                rb.linearVelocity = Vector2.zero;
                Debug.Log("NextPlanetEventZXC");
                NextPlanetEvent();
            }
            _collider.enabled = false;
        }
    }
    private void NextPlanetEvent()
    {
        MessageAboutNextPlanet.Instance.NextPlanetEvent();
    }
}
