using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrapController : MonoBehaviour
{
    public float distance = 5f;
    private float startPosition;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position.x;
    }

    private void Update()
    {
        Vector2 newPosition = new Vector2(startPosition + Mathf.PingPong(Time.time, distance), rb.position.y);
        rb.MovePosition(newPosition);

        
        Debug.Log(Mathf.PingPong(Time.time, distance));
    }

    
}
