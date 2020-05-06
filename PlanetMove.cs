using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMove : MonoBehaviour
{
    public GameObject params_folder;
    Vector3 mousePosition;
    Vector3 init_pos;

    private void OnMouseDrag()
    {
        mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y);
        transform.position += Camera.main.ScreenToWorldPoint(mousePosition) - init_pos;
        init_pos = Camera.main.ScreenToWorldPoint(mousePosition);
    }
    private void OnMouseDown()
    {
        init_pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        foreach (Planet p in Gravity.planets)
        {
            if(p.selected)
            {
                if (p.Game_obj != this.gameObject)
                    p.selected = false;
            }
        }
        Gravity.GetPlanet(this.gameObject).moused = true;
        Gravity.GetPlanet(gameObject).selected = true;
    }
    private void OnMouseUp()
    {
        Gravity.GetPlanet(this.gameObject).moused = false;
    }
}
