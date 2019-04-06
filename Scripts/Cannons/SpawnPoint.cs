using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public static Vector3 SpawnPointPosition;

    private void Update()
    {
        SpawnPointPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
