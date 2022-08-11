using UnityEngine;

public class WaterCrystall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<Water>(out Water water))
        {
            if (collider.gameObject.TryGetComponent<Player>(out Player player))
            {
                player.AddCrystall();
                Destroy(gameObject);
            }
        }
    }
}