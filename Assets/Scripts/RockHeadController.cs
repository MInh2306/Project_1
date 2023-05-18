using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHeadController : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 2f;
    Vector2 moveDirec;

    [SerializeField] private bool isMovingRight = false;
    [SerializeField] private bool isMovingUp = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        float moveHorizontal = isMovingRight ? 1f : -1f;
        float moveVertical = isMovingUp ? 1f : -1f;

        rb.velocity = new Vector2(moveHorizontal * moveSpeed, moveVertical * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isMovingRight = !isMovingRight;
            isMovingUp = !isMovingUp;
        }
    }
}
