using UnityEngine;

public class ReturnToHome : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float homePositionY = -1.57f;
    public void Return()
    {
        player.transform.position = new Vector2(0, homePositionY);
    }
}
