using UnityEngine;

public class Constraint : MonoBehaviour
{
    [SerializeField] private Transform targetPlanet;
    private Rigidbody2D _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Quaternion rotation = Quaternion.FromToRotation(-transform.up, targetPlanet.position - transform.position);
        transform.rotation = rotation * transform.rotation;
    }
}
