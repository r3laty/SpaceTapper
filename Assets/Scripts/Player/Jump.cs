using System;
using System.Collections;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public bool Swiped { get => _hasSwiped; set => _hasSwiped = value; }
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float minSwipeDistance = 50f;

    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;
    private Rigidbody2D _rb;
    private Constraint _constraint;
    private bool _hasSwiped;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _constraint = GetComponent<Constraint>();

        MessageAboutNextPlanet.Instance.NextPlanet += AvailableSwipes;
    }
    private void Start()
    {
        _rb.linearVelocity = Vector2.zero;
    }

    private void Update()
    {
        if (Input.touchCount > 0 && !_hasSwiped)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _startTouchPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                _endTouchPosition = touch.position;
                ProcessSwipe();
            }
        }
    }

    private void ProcessSwipe()
    {
        float swipeDistance = Vector2.Distance(_startTouchPosition, _endTouchPosition);

        if (swipeDistance > minSwipeDistance)
        {
            Vector2 direction = (_endTouchPosition - _startTouchPosition).normalized;
            _rb.linearVelocity = direction * jumpForce;
            _constraint.enabled = false;
        }
        _hasSwiped = true;
        _rb.bodyType = RigidbodyType2D.Dynamic;
    }
    private void OnDisable()
    {
        MessageAboutNextPlanet.Instance.NextPlanet -= AvailableSwipes;
    }
    public void AvailableSwipes()
    {
        _hasSwiped = false;
    }
}
