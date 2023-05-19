using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControl : MonoBehaviour
{
    public float movingSpeed = 2f;
    public bool Horizontal_movement = false;
    public bool Vertical_movement = false;
    //GameObject standableUP;
    // Start is called before the first frame update
    void Start()
    {
        //standableUP = GameObject.Find("StandableUP");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Horizontal_movement)
        {
            transform.position += new Vector3(movingSpeed, 0, 0) * Time.deltaTime;
        }
        else if (Vertical_movement)
        {
            transform.position += new Vector3(0, movingSpeed, 0) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag ("Ground")|| collision.gameObject.CompareTag("MapBorder"))
        {
            movingSpeed = -movingSpeed;
        }
    }
}
