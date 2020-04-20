using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class protagonist : MonoBehaviour {
    public float force = 1;
    private float walkspeed = 6.5f;
    Animator ani_control;
    new Rigidbody2D rigidbody2D;
    bool isAir=false;
    public lightwave lightwave;
    GameObject newave;
	// Use this for initialization
	void Start () {
        Debug.Log("start");
        ani_control = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        }
	
	// Update is called once per frame
	void Update () {
        
      /*  Debug.Log("update");
        float movex = 0;
            if (Input.GetButton("Left"))
            {
            Debug.Log("walk");
            movex += walkspeed * Time.deltaTime;
                ani_control.SetTrigger("walk");

            }
            else if (Input.GetKey(KeyCode.A))
            {
                movex -= walkspeed * Time.deltaTime;
                ani_control.SetTrigger("walk_back");
            }
           
            else
            {
                ani_control.SetTrigger("stand");
            }
            this.transform.Translate(new Vector2(movex, 0));
        */
       
    }

     void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Jump();
            // rigidbody2D.AddForce(Vector2.up * 5);
        }
        else if (Input.GetKey(KeyCode.J))
        {
            Debug.Log("shoot");
            shootwave(new Vector2(this.transform.localPosition.x + 1, this.transform.localPosition.y));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("press D");
            rigidbody2D.velocity = new Vector2(2f, 0);
          //  rigidbody2D.AddForce(new Vector2(force*1, 0));
            if(!isAir)
                ani_control.SetTrigger("walk");

        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigidbody2D.velocity = new Vector2(-2f, 0);
           if(!isAir)
            ani_control.SetTrigger("walk_back");
        }
        else
        {
            ani_control.SetTrigger("stand");
        }
    }

    private void Jump()
    {
       
        if (!isAir)
        {
            rigidbody2D.AddForce(new Vector2(0, 1200f));
         if (Input.GetKey(KeyCode.A))
            {
            
                ani_control.SetBool("jump_back", true);
            }else if (Input.GetKey(KeyCode.D))
            {
                ani_control.SetBool("jump", true);
            }
            isAir = true;
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAir)
        {
            Debug.Log("OnCollisionEnter2D");
            isAir = false;
            ani_control.ResetTrigger("jump");
            ani_control.SetTrigger("stand");
        }
    }
    void shootwave(Vector2 pos)
    {
        newave=(GameObject)Instantiate(lightwave.gameObject, pos, Quaternion.identity);
        Destroy(newave, 3);
    }
}