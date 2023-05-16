using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallingSpeed = 2f;
    [SerializeField] bool isFalling;

    public int fallingDelay = 3;
    float timecount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isFalling)
        {
            timecount += Time.deltaTime;
            if (timecount > fallingDelay)
            {
                transform.position += new Vector3(0f, -fallingSpeed, 0f) * Time.deltaTime;
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
