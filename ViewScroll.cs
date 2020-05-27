using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class ViewScroll : MonoBehaviour
{
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
    }
}
