using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [SerializeField]
    private float _enemySpawnTime = 5.0f;
    [SerializeField]
    private GameObject _enemyShipPrefab;
    [SerializeField]
    private GameObject[] _powerUps;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPowerup());
        StartCoroutine(EnemySpawnTime());
	}

    //coroutin to spawn enemy every 5 seconds
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(_enemyShipPrefab, new Vector3(Random.Range(-9f, 9f), 7f, 0), Quaternion.identity);
            yield return new WaitForSeconds(_enemySpawnTime);
        }
       

    }
    
    IEnumerator SpawnPowerup()
    {
        while (true)
        {
            int randomPowerup = Random.Range(0, 3);
            Instantiate(_powerUps[randomPowerup], new Vector3(Random.Range(-9f, 9f), 7f, 0), Quaternion.identity);

            yield return new WaitForSeconds(10f);

        }
    }

    IEnumerator EnemySpawnTime()
    {
        while (_enemySpawnTime > .5f)
        {
            yield return new WaitForSeconds(12f);

            _enemySpawnTime /= 2;
        }
    }
}
