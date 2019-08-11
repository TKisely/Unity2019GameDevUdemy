using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private GameObject enemyContainer;

    [SerializeField]
    private float hardness = 10.0f;

    [SerializeField]
    private GameObject triplePrefab;

    [SerializeField]
    private GameObject speedPrefab;

    [SerializeField]
    private GameObject shieldPrefab;

    [SerializeField]
    private GameObject[] AllPowerUps;

    [SerializeField]
    private GameObject asteroidPrefab;

    private bool isPlayerAlive = true;
    private int horizontalBoundary = 11;
    private int verticalBoundary = 7;
    

    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
        StartCoroutine(SpawnAsteroidRoutine());
    }

    /*public void corutineStarter()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }*/
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while(isPlayerAlive)
        {
            Vector3 positionToSpawn = new Vector3(
                Random.Range((-1*horizontalBoundary),horizontalBoundary)
                ,verticalBoundary
                , 0);
            GameObject newEnemy = Instantiate(enemyPrefab, positionToSpawn, Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(3.0f);
        }
        
    }

    IEnumerator SpawnAsteroidRoutine()
    {
        while (isPlayerAlive)
        {
            Vector3 positionToSpawn = new Vector3(
                Random.Range((-1 * horizontalBoundary), horizontalBoundary)
                , verticalBoundary
                , 0);
            GameObject asteroid = Instantiate(asteroidPrefab, positionToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(10.0f);
        }
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        while (isPlayerAlive)
        {
            int powerUpNum = Random.Range(0, 3);
            Vector3 randomPos = new Vector3(
                Random.Range((-1 * horizontalBoundary), horizontalBoundary)
                , verticalBoundary
                , 0);
            Instantiate(AllPowerUps[powerUpNum], randomPos, Quaternion.identity);
            
            yield return new WaitForSeconds(10.0f);
        }
        
    }

    public void onPlayerDeath()
    {
        isPlayerAlive = false;
    }
}
