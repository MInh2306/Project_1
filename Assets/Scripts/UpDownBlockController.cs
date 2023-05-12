using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownBlockController : MonoBehaviour
{
    public float movingSpeed = 2f;
    [SerializeField] private bool isMovingDown = false;
    [SerializeField] private bool isMovingUp = false;
    // Start is called before the first frame update
    void Start()
    {
        //cài đặt vị trí đầu tiên cho block;
        transform.position = new Vector3(-7, 6.5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //giới hạn vị trí di chuyển khi đi xuống
        if (isMovingDown && transform.position.y >= 2.5 )
        {
            transform.position += new Vector3(0, -movingSpeed, 0) * Time.deltaTime;
            
        }
        //giới hạn vị trí di chuyển khi đi lên
        if (isMovingUp && isMovingDown == false  && transform.position.y <= 6.5f)
        {
            transform.position += new Vector3(0, movingSpeed, 0) * Time.deltaTime;
            
        }
    }

    //void này dùng để liên kết với trigger, khi trigger đạp vào thì sẽ gọi void này ra
    public void Move()
    {
        isMovingDown = true;
    }

    //khi player nhảy lên block thì sẽ tự độnng di chuyển lên
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            isMovingUp = true;
            isMovingDown = false;
        }
    }
}
