using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public float jumpforce = 680f;
    public float maxSpeed = 5f;
    public float walkForce = 30f;

    private bool facingRight = true;
    private float moveDirection; // hướng di chuyển

    public GameObject shootingPoint;
    public GameObject bulletPrefab;

    Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) //để không nhảy nhiều lần trên không trung (dùm tạm khi nào tạo hàm checkground sau)
        {
            if(rigid2D.velocity.y == 0)
            {
                this.rigid2D.AddForce(transform.up * this.jumpforce);
            }
            
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
        
        //di chuyen trai phai
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

        //Chuyển animation
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            //Trigger Animation RUn khi ấn nút di chuyển
            animator.SetBool("isRunning", true);
        }
        else
        {
            //chuyển lại trạng thái idle khi không ấn nút
            animator.SetBool("isRunning", false);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            transform.position = new Vector3(-8, -2, 0); //test trạm Trap thì sẽ quay lại điểm bắt đầu
        }
        //khi player nhảy lên cục movingblock thì sẽ di chuyển theo
        if (collision.gameObject.name == "StandableUP")
        {
            transform.position = new Vector3(collision.gameObject.transform.position.x, 0, 0);
        }
    }



}
