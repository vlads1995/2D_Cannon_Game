using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private const float SpawnTime = 8f;

    [SerializeField]
    private GameObject _enemyPlaceholer;
    
    private void Start()
    {
        StartCoroutine(Spawn()); 
    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(SpawnTime);
        Instantiate(_enemyPlaceholer, Vector3.zero, Quaternion.identity);
        StartCoroutine(Spawn());
    }

}
