using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public static Vector3 spawnPointPosition;

    void Update()
    {
        spawnPointPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
