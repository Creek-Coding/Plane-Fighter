using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform respawn_point;

    [SerializeField]
    private Transform attackpoint1;

    [SerializeField]
    private Transform attackpoint2;

    [SerializeField]
    private GameObject bulletprefab;

    public float firedelay = 0.25f;
    float cooldownTimer = 0f;

    public int lives = 3;
    bool got_hit = false;

    public float maxSpeed = 7f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        BulletShot();
        PlayerHealth();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        got_hit = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boost")
        {
            BoostHit(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

    void Move()
    {
        Vector3 movement = new Vector3();

        movement.y += Input.GetAxis("Vertical");
        movement.x += Input.GetAxis("Horizontal");

        movement.Normalize();

        movement *= Time.deltaTime * maxSpeed;

        transform.position += movement;
    }

    void BulletShot()
    {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer <= 0)
        {
            cooldownTimer = firedelay;

            Instantiate(bulletprefab, attackpoint1.position, Quaternion.identity);
            Instantiate(bulletprefab, attackpoint2.position, Quaternion.identity);
        }
    }

    void BoostHit(GameObject boost)
    {
        switch (boost.name)
        {
            case "health_powerup(Clone)":
                lives++;
                Debug.Log(lives);
                break;
            case "speed_boost(Clone)":
                maxSpeed += 21/maxSpeed;
                break;
            case "spread_shot(Clone)":
                Debug.Log("BOOM");
                break;
            default:
                Debug.Log(boost.name);
                break;
        }
    }

    void PlayerHealth()
    {
        if (got_hit)
        {
            lives -= 1;
            maxSpeed = 7;
            transform.position = respawn_point.position;
            got_hit = false;
        }
    }
}
