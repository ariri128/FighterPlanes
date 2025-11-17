using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    public float verticalSpeed = 1.5f;
    public float horizontalSpeed = 2f;
    public float horizontalLimit = 1f;

    private float initialX;
    private int direction = 1;

    public GameObject explosionPrefab;
    private GameManager gameManager;

    void Start()
    {
        initialX = transform.position.x;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        float horizontalMovement = direction * horizontalSpeed * Time.deltaTime;

        Vector3 movement = new Vector3(horizontalMovement, -verticalSpeed * Time.deltaTime, 0);


        transform.Translate(movement);

        if (transform.position.x > initialX + horizontalLimit)
        {
            direction = -1;
        }
        else if (transform.position.x < initialX - horizontalLimit)
        {
            direction = 1;
        }

        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Player")
        {
            whatDidIHit.GetComponent<PlayerController>().LoseALife();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (whatDidIHit.tag == "Weapons")
        {
            Destroy(whatDidIHit.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameManager.AddScore(5);
            Destroy(this.gameObject);
        }
    }
}