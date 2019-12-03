using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    [SerializeField]
    public Wave[] waves;

    public Transform[] spawnPoints;

    public Grid grid;

    public float timeBetweenWaves = 30.0f;

    [SerializeField]
    private float countdown = 2f;

    private int waveIndex = 0;

    private int enemiesAlive = 0;

    public GameObject player;
    public GameObject trapSelector;

    void Awake()
    {
        countdown = 2f;
    }

    public void updateWaveSpawn()
    {
        if (enemiesAlive > 0)   //don't restart cooldown when enemies are alive
        {
            return;
        }
        if (waveIndex == waves.Length)
        {
            Debug.Log("Win");
            this.enabled = false;
        }
        if (countdown <= 0f)
        {

            StartCoroutine("Wave");
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

    }

    IEnumerator Wave()
    {
        Wave wave = waves[waveIndex];
        enemiesAlive += wave.count * 3;
        Debug.Log("Wave Incoming");
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(waves[waveIndex].enemy, waves[waveIndex].level);
            yield return new WaitForSeconds(wave.rate);
        }
        waveIndex++;
    }

    void SpawnEnemy(GameObject _enemy, int orc_level)
    {
        foreach (Transform point in spawnPoints)
        {

        }
    }

    public void reset()
    {
        if (waveIndex == 0)
        {
            countdown = 0f;
        }
        else
        {
            countdown = 15f;
        }
        waveIndex = 0;
        enemiesAlive = 0;
    }
    public int getWaveIndex()
    {
        return waveIndex;
    }
    public int getEnemiesAlive()
    {
        return enemiesAlive;
    }
    public void setEnemiesAlive(int new_enemies_alive)
    {
        enemiesAlive = new_enemies_alive;
    }

    public void setWaves(Wave[] newwaves)
    {
        waves = newwaves;
    }
}
