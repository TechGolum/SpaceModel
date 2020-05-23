using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class ViewScroll : MonoBehaviour
{
    static public bool v2 = false;
    static public bool changed = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.up * 10 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * 10 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * 10 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
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
            if(v2)
            {
                transform.Rotate(-90, 0, 0);
                transform.position = new Vector3(transform.position.x, transform.position.z, -transform.position.y);
            }
            else
            {
                transform.Rotate(90, 0, 0);
                transform.position = new Vector3(transform.position.x, -transform.position.z, transform.position.y);
            }
            changed = false;
        }
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Tab))
        {
            if (v2) V1();
            else V2();
        }
    }

    public void V1()
    {
        if (v2) changed = true;
        v2 = false;
    }

    public void V2()
    {
        if (!v2) changed = true;
        v2 = true;
    }
}
