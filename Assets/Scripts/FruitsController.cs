using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsController : MonoBehaviour
{
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //chạm vào nhân vật thì sẽ play animtion collected
            animator.SetTrigger("isCollected");
        }
    }

    //sau khi chạy xong animation collected thì sẽ xóa vật thể được gắn script này
    public void EndAni_Destroy()
    {
        //Debug.Log("End");
        Destroy(gameObject);
    }
}
