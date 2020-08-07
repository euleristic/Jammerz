using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyTypes = new List<GameObject>();
    [SerializeField] List<int> enemiesPerWave = new List<int>();
    [SerializeField] Vector2 screenSize;
    public int aliveEnemies = 0;
    float timer = 0.0f;
    public float downTimeLength;
    int currentEnemyType = 0;
    enum WaveState { CHECKINGIFDONE, DOWNTIME }
    WaveState currentState;

    void SpawnWave(int numOfEnemies, int enemyType)
    {
        aliveEnemies = numOfEnemies;
        for (int i = 0; i < numOfEnemies; i++)
            GameObject.Instantiate(enemyTypes[enemyType],
                new Vector3(Camera.main.transform.position.x + screenSize.x / 2 + 1 + i, 
                Camera.main.transform.position.y + Random.Range(-screenSize.y / 2, screenSize.y / 2)), enemyTypes[i].transform.rotation);
    }

    private void Update()
    {
        switch (currentState)
        {
            case WaveState.CHECKINGIFDONE:
                if (aliveEnemies == 0)
                {
                    currentState = WaveState.DOWNTIME;
                    currentEnemyType++;
                }
                break;
            case WaveState.DOWNTIME:
                timer += Time.deltaTime * TimeManager.GetTimeFactor();
                if (timer > downTimeLength)
                {
                    SpawnWave(enemiesPerWave[currentEnemyType], currentEnemyType);
                    currentState = WaveState.CHECKINGIFDONE;
                }
                break;
            default:
                //Please don't...
                break;
        }
    }
}