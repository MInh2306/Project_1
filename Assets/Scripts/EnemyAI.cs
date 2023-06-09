﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject target;

    //Chasing
    public float chasingRange = 10f;
    public float speed = 2f;
    public float chasingSpeed = 4f;
    public GameObject spawnPos;
    public bool isChasing = false;

    //Facing 
    private Vector3 prePos;
    [SerializeField] bool facingLeft = true;

    //Animation
    Animator animator;

    //Be shooted
    int count = 0;

    //Jump
    Rigidbody2D rb;
    public float jumpForce = 500f;
    



    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.Find("Player");
        prePos = transform.position; // hướng hiện tại

        //Animator
        animator = GetComponent<Animator>();

        //Jump
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rb.velocity.y);
        //---------------------Movement----------------------------------------
        //tính toán khoảng cách giữa 2 nhân vật
        float distance = Vector2.Distance(transform.position, target.transform.position);
        //kcach giữa nhân vật và điểm hồi sinh
        float distanceToSpawn = Vector2.Distance(transform.position, spawnPos.transform.position);

        //Chasing
        if(distance < chasingRange)
        {
            isChasing = true;
            //Chỉ di chuyển theo trục x
            float targetX = target.transform.position.x - 1f; //để nó không trùng luôn với vị trí player
            Vector2 newPosition = new Vector2(targetX, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, newPosition, chasingSpeed * Time.deltaTime);

            //di chuyển theo x, y như topdown
            //transform.position = Vector2.MoveTowards(transform.position, target.transform.position, chasingSpeed * Time.deltaTime);

            //kích hoạt animation Run
            animator.SetBool("isRunning", true);
            animator.SetBool("isWalking", false);
        }
        else
        {
            if(distanceToSpawn > 0.5f)
            {
                
                //quay lại vị trí ban đầu khi không đuổi nữa
                transform.position = Vector2.MoveTowards(transform.position, spawnPos.transform.position, speed * Time.deltaTime);
                animator.SetBool("isWalking", true); // đoạn này chuyển thành animation Walk
            }
            else
            {
                //Khi distanceToSpawn < 2 tức là đã quayt về điểm ban đầu thì sẽ đứng yên
                animator.SetBool("isWalking", false); // từ Walk -> idle

                isChasing = false;

            }
            
            //Kích hoạt animation idle
            animator.SetBool("isRunning", false);
            
        }

        

        //---------------------------FACING------------------------------------

        //lưu lại vị trí hiện tại của nhân vật
        Vector3 currentPos = transform.position;

        //Vector xác định hướng đi của nhân vật
        Vector3 moveDirec = currentPos - prePos;

        //Kiểm tra hướng di chuyển
        if(moveDirec.x > 0 && facingLeft)
        {
            Flip();
            //Nhân vật đang đi qua phải
            //Debug.Log("qua phải");
            
        }
        else if(moveDirec.x < 0 && !facingLeft)
        {
            Flip();
            //Nhân vật đang đi qua trái
            //Debug.Log("qua trái");
            // Quay nhân vật về phía hướng di chuyển
           
        }
        

        prePos = currentPos; //Lưu lại vị trí hiện tại để sử dụng cho lần cập nhật tiếp theo
        


        //QUay lại vị trí ban đầu nếu lỡ đi quá xa hoặc rớt xuống
        if (transform.position.y <= 3f)
        {
            transform.position = spawnPos.transform.position;
        }

        

    }
    void Flip()
    {
        // Đảo hướng quay nhân vật
        facingLeft = !facingLeft;
        transform.Rotate(0f, 180f, 0f);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        //kích hoạt animation bị bắn và đếm số đạn bị bắn rồi chết
        if(collision.gameObject.tag == "Bullet")
        {
            animator.SetBool("isHitted",true);
            count++;
            Debug.Log(count);
            if(count >= 10)
            {
                Destroy(gameObject);
                //nên thêm cái nổ trước khi chớt
            }
        }
        else
        {
            animator.SetBool("isHitted", false);
        }

        //Jump
        if(collision.gameObject.tag == "Ground" && isChasing == true && rb.velocity.y <= 0)
        {
            rb.AddForce(transform.up * jumpForce);
        }

    }
}
