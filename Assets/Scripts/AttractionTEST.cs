using System;
using UnityEngine;

public class AttractionTEST : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(CompareTags.Player))
        {
            Debug.Log("Trigger enter + " + other.name + " in " + name);
            if (other.TryGetComponent(out Rigidbody2D rb))
            {
                Debug.Log("Rigidbody found");
                rb.linearVelocity = Vector2.zero;
            }
            MessageAboutNextPlanet.Instance.NextPlanetEvent();
        }
    }
}
