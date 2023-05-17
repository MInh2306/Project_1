using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallingSpeed = 2f;
    [SerializeField] bool isFalling;

    Rigidbody2D rb;

    public int fallingDelay = 3;
    float timecount;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isFalling)
        {
            timecount += Time.deltaTime;
            if (timecount > fallingDelay)
            {
                //rb.AddForce(Vector2.down*fallingSpeed);
                transform.Translate(0f, -fallingSpeed * Time.deltaTime, 0f);
            }
            
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isFalling = true;
        }
        Debug.Log(collision.gameObject.tag);
    }
}
