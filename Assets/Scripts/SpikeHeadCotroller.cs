using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHeadCotroller : MonoBehaviour
{
    public float speed;
    Animator animator;

    //cài đặt để chọn di chuyển phải or trái
    public bool Horizontal_movement = false;
    public bool Vertical_movement = false;

    //đế tính toán vận tốc thì cần rigidbody
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //lên xuống
        //transform.Translate(Vector2.up * speed * Time.deltaTime);
        //không dùng transform vì dùng addfỏce sẽ tự nhiên hơn
        if (Horizontal_movement)
        {
            rb.AddForce(Vector2.right * speed);
        }else if (Vertical_movement)
        {
            rb.AddForce(Vector2.up * speed);
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D object_rb = collision.collider.GetComponent<Rigidbody2D>(); // lấy rigibody của vật thể va chạm với vật thể này
        if(object_rb != null)
        {
            speed = -speed;
            animator.Play("SpikeHead_Top");
        }
    }
}
