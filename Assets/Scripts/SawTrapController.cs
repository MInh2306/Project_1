using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrapController : MonoBehaviour
{
    //TRAP NÀY LUÔN DI CHUYỂN TRÁI PHẢI
    public float speed = 3f;

    //float time = 0; //mốc thời gian ban đầu là 0
    //public double timetocomeback = 3f; //set tup cho cứ mỗi 3s thì sẽ chuyển hướng theo chiều ngược lại;

    Vector3 startPos; // Lưu vị trí bắt đầu
    public float distance = 3f; // khoảng cách tối đa di chuyển

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // lấy vị trí ban đầu
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x - startPos.x > distance) //lớn hơn khoảng cách tối đa thì sẽ di chuyển ngược lại
        {
            transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        }
        else
        {
            transform.Translate(speed * Time.deltaTime, 0f, 0f); //Translate là sử dụng Vector để di chuyển, còn position là di chuyển theo mặt phẳng tọa độ 2D
        }
        


        /*time += Time.deltaTime; //thời gian sẽ tăng dần
        if (time > timetocomeback) //sau 3s thì qua phải
        {
            //transform.position += new Vector3(speed,0f,0f)*Time.deltaTime;
            
            transform.Translate(speed * Time.deltaTime, 0f, 0f); //Translate là sử dụng Vector để di chuyển, còn position là di chuyển theo mặt phẳng tọa độ 2D
            //sau khi qua phải 3s (vì lúc này đã qua 3s đầu rồi nên nếu them 3s nữa thì maxtime + 3)
            if(time > timetocomeback * 2) 
            {
                //đếm lại từ đầu
                time = 0;
            }
        }
        else //trước 3s đầu thì qua trái
        {
            //transform.position += new Vector3(-speed, 0f, 0f) * Time.deltaTime;
            
            transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        }*/
    }
}
