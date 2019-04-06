using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPlaceholer;
    private float _spawnTime = 8f;
    
    void Start()
    {
        StartCoroutine(StartSpawn()); 
    }

    private IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(_spawnTime);
        Instantiate(_enemyPlaceholer, Vector3.zero, Quaternion.identity);
        StartCoroutine(StartSpawn());
    }

}
