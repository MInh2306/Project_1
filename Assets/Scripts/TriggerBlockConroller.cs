using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlockConroller : MonoBehaviour
{
    public UpDownBlockController chossen_updownblock; //các lấy script từ object khác
    //public float block_movingspeed;

    public Sprite pressed;
    public Sprite release;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //gắn sprite ban đầu
        spriteRenderer.sprite = release; 
    }

    // Update is called once per frame
    void Update()
    {
        //di chuyển cục block or cửa
        //triggerblock.transform.position += new Vector3(0, block_movingspeed, 0f) * Time.deltaTime;
    }

    //khi player đạp lên nút bấm
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //chuyển đổi sprite
            spriteRenderer.sprite = pressed;

            //đạp lên nút bấm đồng thời di chuyển block
            chossen_updownblock.Move();
           
        }
    }

    //khi player không đạp lên, hoặc đi ra
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //chuyển đổi sprite
            spriteRenderer.sprite = release;
        }
    }
}
