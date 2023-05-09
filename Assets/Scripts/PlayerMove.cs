using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpforce = 680f;
    public float maxSpeed = 5f;
    public float walkForce = 30f;

    private bool facingRight = true;
    private float moveDirection; // hướng di chuyển

    public GameObject shootingPoint;
    public GameObject bulletPrefab;


    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.rigid2D.AddForce(transform.up * this.jumpforce);
        }
        // Lấy giá trị ngang của trục
        moveDirection = Input.GetAxis("Horizontal");

        // Xác định hướng quay nhân vật
        if (moveDirection > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveDirection < 0 && facingRight)
        {
            Flip();
        }
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (speedx < maxSpeed)
            {
                rigid2D.AddForce(Vector2.right * moveDirection * walkForce);
            }

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (speedx < maxSpeed)
            {
                rigid2D.AddForce(Vector2.right * moveDirection * walkForce);
            }

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

    }

    void Flip()
    {
        // Đảo hướng quay nhân vật
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void Fire()
    {
        Instantiate(bulletPrefab, shootingPoint.transform.position, shootingPoint.transform.rotation);
    }



}
