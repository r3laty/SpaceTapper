using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Rigidbody2D _playerRb;
    private Animator _playerAnimator;
    private void Start()
    {
        _playerRb = player.GetComponent<Rigidbody2D>();
        _playerAnimator = player.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(CompareTags.Player))
        {
            _playerRb.bodyType = RigidbodyType2D.Kinematic;
            _playerRb.linearVelocity = Vector2.zero;
            _playerAnimator.SetTrigger("Nothing");
        }
        //death menu in canvas
    }
}
