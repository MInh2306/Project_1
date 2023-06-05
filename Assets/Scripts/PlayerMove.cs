using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Moving
    Rigidbody2D rigid2D;
    public float jumpforce = 680f;
    public float maxSpeed = 5f;
    public float walkForce = 30f;
    [SerializeField] private bool groundCheck = false;
    //Flip
    private bool facingRight = true;
    private float moveDirection; // hướng di chuyển
    //Shotting
    public GameObject shootingPoint;
    public GameObject bulletPrefab;
    //Animation
    Animator animator;

    //SpawnPoint
    public GameObject spawnpoint;

    //mobile
    public bool R_Button = false;
    public bool L_Button = false;


    // Start is called before the first frame update
    void Start()
    {
        //Moving
        rigid2D = GetComponent<Rigidbody2D>();
        //Animation
        animator = GetComponent<Animator>();
        //spawnpoint
        //spawnpoint = GameObject.Find("SpawnPoint");
    }

    // Update is called once per frame
    void Update()
    {
        //JUMP
        if (Input.GetKeyDown(KeyCode.UpArrow)) //để không nhảy nhiều lần trên không trung (dùm tạm khi nào tạo hàm checkground sau)
        {
        
            if (groundCheck)
            {
                this.rigid2D.AddForce(transform.up * this.jumpforce);
                
            }

        }
        
        // Lấy giá trị ngang của trục
        //moveDirection = Input.GetAxis("Horizontal"); hàm này lấy giá trị chính xasc hơn bao gồm cả số thập phân
        moveDirection = Input.GetAxisRaw("Horizontal"); //hàm này cũng giống nhưng chỉ lây -1, 0, 1

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
        if (Input.GetKey(KeyCode.RightArrow) || R_Button)
        {

            if (speedx < maxSpeed)
            {
                rigid2D.AddForce(Vector2.right * moveDirection * walkForce);
            }

        }

        if (Input.GetKey(KeyCode.LeftArrow) || L_Button)
        {

            if (speedx < maxSpeed)
            {
                rigid2D.AddForce(Vector2.right * moveDirection * walkForce);
            }

        }


        //Chuyển animation
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            //Trigger Animation RUn khi ấn nút di chuyển
            animator.SetBool("isRunning", true);
        }
        else
        {
            //chuyển lại trạng thái idle khi không ấn nút
            animator.SetBool("isRunning", false);
        }

        /*if (Input.GetKeyDown(KeyCode.UpArrow)) //để không nhảy nhiều lần trên không trung (dùm tạm khi nào tạo hàm checkground sau)
        {
            animator.SetBool("isJumpping", true);
        }
        else
        {
            animator.SetBool("isJumpping", false);
        }*/
        //Debug.Log(rigid2D.velocity.y);
        if(rigid2D.velocity.y > 0)
        {
            animator.SetBool("isJumpping", true);
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isJumpping", false);
        }

        if(rigid2D.velocity.y < 0)
        {
            animator.SetBool("isFalling", true);
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumpping", false);
        }
        else
        {
            animator.SetBool("isFalling", false);
        }
        //Wall stick fix
        
        //Shot
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

    //Ground check 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "MovingBlock" || collision.gameObject.tag == "MapBorder")
        {
            groundCheck = true;
        }

        if (collision.gameObject.tag == "Trap")
        {
            //transform.position = new Vector3(-8, -2, 0); 
            transform.position = spawnpoint.transform.position; // quay lại spawwpoint or checkpoint
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "MovingBlock" || collision.gameObject.tag == "MapBorder")
        {
            groundCheck = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "MovingBlock" || collision.gameObject.tag == "MapBorder")
        {
            groundCheck = false;

        }
    }


    //Chạm vào trap là trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            //transform.position = new Vector3(-4.38f, 1.61f, 0); //test trạm Trap thì sẽ quay lại điểm bắt đầu
            transform.position = spawnpoint.transform.position;
            //Debug.Log(transform.position);
        }
        
        
    }

    //Ipad controller
    public void MoveLeft()
    {
        moveDirection = -1;
        L_Button = true;
        Debug.Log("moveDirection: " + moveDirection);
    }

    public void MoveRight()
    {
        moveDirection = 1;
        R_Button = true;
        Debug.Log("moveDirection: " + moveDirection);
    }

    public void StopMoving()
    {
        moveDirection = 0f;
    }

    public void UpButtonDown()
    {
        Debug.Log("Up pressed");
    }



}
