using UnityEngine;

public class Player : MonoBehaviour
{
    private int _crystallsCount;

    private void Start()
    {
        _crystallsCount = 0;
    }

    public void AddCrystall()
    {
        _crystallsCount++;
        Debug.Log(gameObject.name + ": " + _crystallsCount);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
