using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float speed=5;
    public Camera cam;
    Ray ray;
    RaycastHit hit;



    float jumpCounter = 0;
    float dashCounter = 0;

   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(timers());
    }

    public RaycastHit getHit()
    {
        return hit;
    }
    // Update is called once per frame
    void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        
        Physics.Raycast(ray, out hit);

        //Debug.Log(hit.point.x+","+hit.point.y+"," + hit.point.z);

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward*speed,ForceMode.Force);            
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-Vector3.forward * speed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-Vector3.right * speed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed, ForceMode.Force);
        }

        if(Input.GetKeyDown(KeyCode.Space)&&jumpCounter>=0)
        {
            jumpCounter--;
            rb.AddForce(Vector3.up*6, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.E)&&dashCounter>=0)
        {
            dashCounter--;
            rb.AddForce(rb.velocity.normalized*25, ForceMode.Impulse);
        }

        transform.LookAt(hit.point);

    }

    public RaycastHit GetRayHit()
    {
        return hit;
    }

    IEnumerator timers()
    {
        while (1 == 1)
        {
            yield return new WaitForSeconds(3.0f);
            jumpCounter = 2;
            dashCounter = 2;
            Debug.Log("set");
        }
    }
}
