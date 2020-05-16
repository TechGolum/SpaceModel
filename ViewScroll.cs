using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class ViewScroll : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.up * 10 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * 10 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * 10 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(-Vector3.left * 10 * Time.deltaTime);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.Equals)) // forward
        {
            transform.Translate(Vector3.forward * 40 * Time.deltaTime);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f || Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.Minus)) // backwards
        {
            transform.Translate(-Vector3.forward * 40 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.X))
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift))
            {
                transform.Rotate(10 * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                transform.Rotate(-10 * Time.deltaTime, 0, 0);
            }
        }
    }

    
}
