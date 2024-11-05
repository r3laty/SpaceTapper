using System;
using System.Collections;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float minSwipeDistance = 50f;

    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;
    private Rigidbody2D _rb;
    private Constraint _constraint;
    private bool _swiped;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _constraint = GetComponent<Constraint>();
    }
    private void Start()
    {
        _rb.linearVelocity = Vector2.zero;
    }

    private void Update()
    {
        if (!_swiped)
        {
            if (Input.touchCount > 0)
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
    }

    private void ProcessSwipe()
    {
        _swiped = true;
        StartCoroutine(ResetSwipe());

        float swipeDistance = Vector2.Distance(_startTouchPosition, _endTouchPosition);

        if (swipeDistance > minSwipeDistance)
        {
            Vector2 direction = (_endTouchPosition - _startTouchPosition).normalized;
            _rb.linearVelocity = direction * jumpForce;
            _constraint.enabled = false;
        }
    }

    private IEnumerator ResetSwipe()
    {
        yield return new WaitForSeconds(0.5f);
        _swiped = false;
    }
}