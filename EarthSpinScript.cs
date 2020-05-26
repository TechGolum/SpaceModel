using UnityEngine;
using System.Collections;

public class EarthSpinScript : MonoBehaviour {
    public float speed = 30f;

    void Update() {
        if(!CreatePlanet.pause)
            transform.Rotate(0, Gravity.GetPlanet(gameObject).Spin * Time.deltaTime, 0, Space.Self);
    }
}