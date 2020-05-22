using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMove : MonoBehaviour
{
    Vector3 mousePosition;
    Vector3 init_pos;

    private void OnMouseDrag()
    {
        if (!Gravity.GetPlanet(gameObject).followed)
        {
            if(!ViewScroll.v2) mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y + transform.position.y, Camera.main.transform.position.y - transform.position.y);
            else mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + Input.mousePosition.z);
            transform.position += Camera.main.ScreenToWorldPoint(mousePosition) - init_pos;
            init_pos = Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }
    private void OnMouseDown()
    {
        CreatePlanet.diselected = CreatePlanet.GetSelectedPlanet() == Gravity.GetPlanet(gameObject);
        if(!ViewScroll.v2) init_pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y + transform.position.y, Camera.main.transform.position.y - transform.position.y));
        else init_pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + Input.mousePosition.z));
        Gravity.GetPlanet(this.gameObject).moused = true;
        foreach(Planet p in Gravity.planets)
        {
            p.selected = false;
        }    
        Gravity.GetPlanet(this.gameObject).selected = true;
    }
    private void OnMouseUp()
    {
        Gravity.GetPlanet(this.gameObject).moused = false;
    }
}
