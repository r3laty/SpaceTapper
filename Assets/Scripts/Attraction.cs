using System;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    private Collider2D _collider;
    private Gravity _gravity;
    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _gravity = GetComponent<Gravity>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(CompareTags.Player))
        {
            Debug.Log("Trigger enter + " + other.name + " in " + name + " TESTING");
            GameObject player = other.gameObject;
            if (player.TryGetComponent(out Rigidbody2D rb))
            {
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.linearVelocity = Vector2.zero;
                Debug.Log("NextPlanetEventZXC");
                NextPlanetEvent();
            }
            _collider.enabled = false;
            _gravity.enabled = false;
        }
    }
    private void NextPlanetEvent()
    {
        MessageAboutNextPlanet.Instance.NextPlanetEvent();
    }
}
