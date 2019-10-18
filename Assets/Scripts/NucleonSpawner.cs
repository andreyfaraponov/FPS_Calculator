using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NucleonSpawner : MonoBehaviour
{
    public float timeBetweenSpawns;

    public float spawnDistance;

    [SerializeField] private Text buttonText;
    private bool isSpawning;

    public Nucleon[] nucleonPrefabs;
    [SerializeField] private Text objectsCount;
    private int nucleonsAndProteonsCounter = 0;
    float timeSinceLastSpawn;

    void FixedUpdate()
    {
        if (!isSpawning) return;
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= timeBetweenSpawns)
        {
            timeSinceLastSpawn -= timeBetweenSpawns;
            SpawnNucleon();
        }
    }

    public void StartStopSpawn()
    {
        isSpawning = !isSpawning;
        buttonText.text = isSpawning ? "STOP" : "START";
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void SpawnNucleon()
    {
        nucleonsAndProteonsCounter++;
        objectsCount.text = nucleonsAndProteonsCounter.ToString();
        Nucleon prefab = nucleonPrefabs[Random.Range(0, nucleonPrefabs.Length)];
        Nucleon spawn = Instantiate(prefab);
        spawn.transform.localPosition = Random.onUnitSphere * spawnDistance;
    }
}