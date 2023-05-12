using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrapController : MonoBehaviour
{
    //TRAP NÀY LUÔN DI CHUYỂN TRÁI PHẢI MỖI 3s
    public float speed = 3f;

    float time = 0; //mốc thời gian ban đầu là 0
    float maxTime = 3f; //set tup cho cứ mỗi 3s thì sẽ chuyển hướng theo chiều ngược lại;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime; //thời gian sẽ tăng dần
        if (time > maxTime) //sau 3s thì qua phải
        {
            transform.position += new Vector3(speed,0f,0f)*Time.deltaTime;
            //sau khi qua phải 3s (vì lúc này đã qua 3s đầu rồi nên nếu them 3s nữa thì maxtime + 3)
            if(time > maxTime * 2) 
            {
                //đếm lại từ đầu
                time = 0;
            }
        }
        else //trước 3s đầu thì qua trái
        {
            transform.position += new Vector3(-speed, 0f, 0f) * Time.deltaTime;
        }
    }
}
