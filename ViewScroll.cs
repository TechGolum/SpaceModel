using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class ViewScroll : MonoBehaviour
{
    static public bool x = false;
    static bool changed = false;
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
        if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.Equals) || Input.GetKey(KeyCode.RightControl) && Input.GetKey(KeyCode.Equals)) // forward
        {
            transform.Translate(Vector3.forward * 40 * Time.deltaTime);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f || Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.RightControl) && Input.GetKey(KeyCode.Minus)) // backwards
        {
            transform.Translate(-Vector3.forward * 40 * Time.deltaTime);
        }
        if(changed)
        {
            if(x)
            {
                transform.Rotate(-90, 0, 0);
                transform.position = new Vector3(0, 0, -transform.position.y);
            }
            else
            {
                transform.Rotate(90, 0, 0);
                transform.position = new Vector3(0, -transform.position.z, 0);
            }
            changed = false;
        }
    }

    public void V1()
    {
        if (x) changed = true;
        x = false;
    }

    public void V2()
    {
        if (!x) changed = true;
        x = true;
    }
}
