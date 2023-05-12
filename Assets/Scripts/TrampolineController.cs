using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineController : MonoBehaviour
{
    public float bounceForce = 600f;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D object_rb = collision.collider.GetComponent<Rigidbody2D>(); //lấy rigidbody của vật thể bị va chạm vào
        
        if (object_rb != null)
        {
            animator.SetBool("isOnTrampoline",true);
            object_rb.AddForce(transform.up * bounceForce, ForceMode2D.Impulse); //Impulse là loại lực đẩy mạnh ngắn
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Rigidbody2D object_rb = collision.collider.GetComponent<Rigidbody2D>(); //lấy rigidbody của vật thể bị va chạm vào

        if (object_rb != null)
        {
            animator.SetBool("isOnTrampoline", false);
        }
    }
}
