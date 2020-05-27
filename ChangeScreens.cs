using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScreens : MonoBehaviour
{
    public Slider D;
    float d;
    static public bool v2 = false;
    static public bool changed = false;
    void Update()
    {
        if (PlanetsInfo.GetFollowedPlanet() != null)
        {
            d = D.value;
            if (!v2)
            {
                Camera.main.transform.position = new Vector3(PlanetsInfo.GetFollowedPlanet().Game_obj.transform.position.x,
                                                         PlanetsInfo.GetFollowedPlanet().Game_obj.transform.position.y + d,
                                                         PlanetsInfo.GetFollowedPlanet().Game_obj.transform.position.z);
            }
            else
            {
                Camera.main.transform.position = new Vector3(PlanetsInfo.GetFollowedPlanet().Game_obj.transform.position.x,
                                                              PlanetsInfo.GetFollowedPlanet().Game_obj.transform.position.y,
                                                              PlanetsInfo.GetFollowedPlanet().Game_obj.transform.position.z - d);
            }
        }
        if (changed)
        {
            if (v2)
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
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Tab))
        {
            Change();
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

    public void Change()
    {
        if (v2) V1();
        else V2();
    }
}
