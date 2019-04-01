using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPlaceholer;
    private float spawnTime = 8f;
    
    void Start()
    {
        StartCoroutine(StartSpawn()); 
    }

    public IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(spawnTime);
        Instantiate(enemyPlaceholer, Vector3.zero, Quaternion.identity);
        StartCoroutine(StartSpawn());
    }

}
