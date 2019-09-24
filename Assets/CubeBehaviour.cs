using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{

    private Rigidbody rb;
    GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.Find("Camera");
    }

    // Update is called once per frame
    void Update()
    {
        var speed = 3f;
        float h = speed * Input.GetAxis("Mouse X");
        float v = speed * Input.GetAxis("Mouse Y");
        cam.transform.Rotate(-v, h, 0);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject ball = GameObject.Find("Ball");
            //Vector3 appear = new Vector3(cam.transform.forward) * .2f;
            GameObject NewBall = Instantiate(ball, (cam.transform.forward * 2f) + transform.position, transform.rotation);
            Rigidbody ballForce = NewBall.GetComponent<Rigidbody>();
            ballForce.AddForce(cam.transform.forward * 1000f);
            Destroy(NewBall, 5.0f);
        }


            if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                print(hit.point);
                GameObject b = GameObject.Find("Barrel");
                Instantiate(b, hit.point + new Vector3(0,2,0), b.transform.rotation);
                Debug.Log("Did Hit");
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }


        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            var camDir = cam.transform.forward * .2f;
            camDir.y = 0;
            var movement = camDir + transform.position;
            print(camDir);
            rb.MovePosition(movement); 
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            var camDir = -cam.transform.right * .2f;
            camDir.y = 0;
            var movement = camDir + transform.position;
            print(camDir);
            rb.MovePosition(movement);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            var camDir = cam.transform.right * .2f;
            camDir.y = 0;
            var movement = camDir + transform.position;
            print(camDir);
            rb.MovePosition(movement);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            var camDir = -cam.transform.forward * .2f;
            camDir.y = 0;
            var movement = camDir + transform.position;
            print(camDir);
            rb.MovePosition(movement);
        }
    }
}
