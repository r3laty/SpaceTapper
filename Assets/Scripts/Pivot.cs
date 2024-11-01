using UnityEngine;

public class Pivot : MonoBehaviour
{
    private Transform _parent;
    private float _radius;

    private void Awake()
    {
        _parent = transform.parent;
        if (_parent.TryGetComponent<Renderer>(out var renderer))
        {
            _radius = Mathf.Min(renderer.bounds.extents.x + 0.3f, renderer.bounds.extents.y + 0.3f);
        }
    }

    private void Update()
    {
        Vector3 localPos = transform.localPosition;
        
        float distance = new Vector2(localPos.x, localPos.y).magnitude;
        
        if (distance > _radius)
        {
            Vector2 normalized = new Vector2(localPos.x, localPos.y).normalized;
            localPos.x = normalized.x * _radius;
            localPos.y = normalized.y * _radius;
        }
        
        transform.localPosition = localPos;
    }
}
