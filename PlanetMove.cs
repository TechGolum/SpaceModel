using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMove : MonoBehaviour
{
    Vector3 mousePosition;
    Vector3 init_pos;

    private void OnMouseDrag()
    {
        if (!PlanetsInfo.GetPlanet(gameObject).followed)
        {
            if (!ChangeScreens.v2)
            {
                mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y + transform.position.y, Camera.main.transform.position.y - transform.position.y);
                transform.position += Camera.main.ScreenToWorldPoint(mousePosition) - init_pos;
                init_pos = Camera.main.ScreenToWorldPoint(mousePosition);
            }
            else transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Math.Abs(Camera.main.transform.position.z -  transform.position.z)));
        }
    }
    private void OnMouseDown()
    {
        if(!ChangeScreens.v2) init_pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y + transform.position.y, Camera.main.transform.position.y - transform.position.y));
        else init_pos = Camera.main.ScreenToWorldPoint(new Vector3(-Input.mousePosition.x, -Input.mousePosition.y + transform.position.z, Camera.main.transform.position.z));
        PlanetsInfo.GetPlanet(this.gameObject).moused = true;
    }
    private void OnMouseUp()
    {
        PlanetsInfo.GetPlanet(this.gameObject).moused = false;
    }
}
