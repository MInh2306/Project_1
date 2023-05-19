using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject target;

    //Chasing
    public float chasingRange = 10f;
    public float speed = 2f;

    //Facing 
    private Vector3 prePos;
    [SerializeField] bool facingLeft = true;


    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.Find("Player");
        prePos = transform.position; // hướng hiện tại
    }

    // Update is called once per frame
    void Update()
    {
        //tính toán khoảng cách giữa 2 nhân vật
        float distance = Vector2.Distance(transform.position, target.transform.position);
        if(distance < chasingRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            
            //kích hoạt animation Run

        }
        else
        {
           //chuyển động qua lại hoặc đứng yên Idle
           
           //Kích hoạt animation walk
        }

        

        //facing

        //lưu lại vị trí hiện tại của nhân vật
        Vector3 currentPos = transform.position;

        //Vector xác định hướng đi của nhân vật
        Vector3 moveDirec = currentPos - prePos;

        //Kiểm tra hướng di chuyển
        if(moveDirec.x > 0 && facingLeft)
        {
            Flip();
            //Nhân vật đang đi qua phải
            Debug.Log("qua phải");
            
        }
        else if(moveDirec.x < 0 && !facingLeft)
        {
            Flip();
            //Nhân vật đang đi qua trái
            Debug.Log("qua trái");
            // Quay nhân vật về phía hướng di chuyển
           
        }

        //Lưu lại vị trí hiện tại để sử dụng cho lần cập nhật tiếp theo
        prePos = currentPos;

        

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
    }
}
