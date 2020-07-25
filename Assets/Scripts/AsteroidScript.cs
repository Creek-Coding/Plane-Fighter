using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{

    public float speed = 7f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float number = Random.Range(-9, 9);
        Vector3 temp = transform.position;
        temp.y -= speed * Time.deltaTime;
        temp.x += number * Time.deltaTime;
        transform.position = temp;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
