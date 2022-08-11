using UnityEngine;

public class FirePuddle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Water>(out Water water))
        {
            collision.gameObject.TryGetComponent<Player>(out Player player);
            player.Die();
        }
    }
}