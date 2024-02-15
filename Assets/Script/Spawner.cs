using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Camera mainCamera;
    float spawnRate = 5f;
    float rateChanger = 0.8f;

    void Start()
    {
        SpawnEnemyOutsideCameraView();
        InvokeRepeating(nameof(newWave), 0.1f, 10f);
        
    }
    void Update()
    {
        // CHANGE THIS!! THIS IS ONLY FOR DEBUGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG
        if(Input.GetKeyDown(KeyCode.F))
        {
            SpawnEnemyOutsideCameraView();
        }
    }
    public void newWave()
    {
        spawnRate *= rateChanger;
        CancelInvoke("SpawnEnemyOutsideCameraView");
        InvokeRepeating(nameof(SpawnEnemyOutsideCameraView), 0.1f,spawnRate);
    }
    public void SpawnEnemyOutsideCameraView()
    {
        Vector2 spawnPosition = CalculateRandomSpawnPositionOutsideCameraView();
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemyPrefab.GetComponent<AsteroidScript>().initializeAsteroid();
    }
    private Vector2 CalculateRandomSpawnPositionOutsideCameraView()
    {
        // mainCamera.
        float randomX;
        float randomY;
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        int isOpposite = Random.Range(0, 2);
        int changeRandom = Random.Range(0, 2);
        if (changeRandom == 0)
        {
            randomX = Random.Range(mainCamera.transform.position.x + cameraWidth, mainCamera.transform.position.x - cameraWidth);
            randomY = cameraHeight + mainCamera.transform.position.y;
            if (isOpposite == 0)
            {
                randomY = -randomY;
            }
        }
        else
        {
            randomY = Random.Range(mainCamera.transform.position.y + cameraHeight, mainCamera.transform.position.y - cameraHeight);
            randomX = mainCamera.transform.position.x + cameraWidth;
            if (isOpposite == 0)
            {
                randomX = -randomX;
            }
        }
        
        // Debug.Log($"this is isOpposite {isOpposite}");
        return new Vector2(randomX, randomY);
    }
    // private IEnumerator delay()
    // {
    //     return new WaitForSeconds(spawnRate);
    // }
}