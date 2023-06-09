using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public GameObject spawnpoint;

    [SerializeField] bool alreadyTouch = false;
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
        if (collision.gameObject.tag == "Player" && alreadyTouch==false)
        {
            spawnpoint.transform.position = this.transform.position;
            animator.SetTrigger("isTouch");
            alreadyTouch = true;

        }
    }
}
