using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float maxSpeed = 7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3();

        movement.y += Input.GetAxis("Vertical");
        movement.x += Input.GetAxis("Horizontal");

        movement.Normalize();

        movement *= Time.deltaTime * maxSpeed;

        transform.position += movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
