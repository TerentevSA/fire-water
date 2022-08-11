using UnityEngine;

public class WaterPaddle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Fire>(out Fire fire))
        {
            collision.gameObject.TryGetComponent<Player>(out Player player);
            player.Die();
        }
    }
}