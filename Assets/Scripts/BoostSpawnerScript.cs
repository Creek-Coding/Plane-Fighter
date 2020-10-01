using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject healthboost;

    [SerializeField]
    private GameObject speedboost;

    [SerializeField]
    private GameObject coneshot;

    float cooldowntimer = 0f;
    float respawntime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnRNG();
    }

    GameObject BoostSelector()
    {
        List<GameObject> boosts = new List<GameObject>();
        boosts.Add(healthboost);
        boosts.Add(speedboost);
        boosts.Add(coneshot);

        int number = Random.Range(0, boosts.Count);

        return boosts[number];
    }

    void SpawnRNG()
    {
        cooldowntimer -= Time.deltaTime;
        if (cooldowntimer <= 0)
        {
            float number = Random.Range(-9, 9);

            Vector3 spawnarea = transform.position;

            spawnarea.x += number;

            Instantiate(BoostSelector(), spawnarea, Quaternion.identity);

            cooldowntimer = respawntime;
        }

    }
}
