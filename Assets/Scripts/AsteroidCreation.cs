using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCreation : MonoBehaviour
{
    float cooldowntimer = 0f;
    float respawntime = 0.5f;
    float number;
    public GameObject asteroidPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnRNG();
    }

    void SpawnRNG()
    {
        cooldowntimer -= Time.deltaTime;
        if (cooldowntimer <= 0)
        {
            number = Random.Range(-9, 9);

            Vector3 spawnarea = transform.position;

            spawnarea.x += number;

            Instantiate(asteroidPrefab, spawnarea, Quaternion.identity);

            cooldowntimer = respawntime;
        }
        
    }
}
