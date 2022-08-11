using UnityEngine;

public class FireCrystall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<Fire>(out Fire fire))
        {
            if (collider.gameObject.TryGetComponent<Player>(out Player player))
            {
                player.AddCrystall();
                Destroy(gameObject);
            }
        }
    }
}