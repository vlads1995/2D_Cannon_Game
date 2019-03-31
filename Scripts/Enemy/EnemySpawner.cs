using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPlaceholer;
    
    void Start()
    {
        StartCoroutine(StartSpawn()); 
    }

    public IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(8.0f);
        Instantiate(enemyPlaceholer, Vector3.zero, Quaternion.identity);
        StartCoroutine(StartSpawn());
    }

}
