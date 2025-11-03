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

    void Start()
    {
        initialX = transform.position.x;
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
}
