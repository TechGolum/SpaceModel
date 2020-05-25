using UnityEngine;
using System.Collections;

public class EarthSpinScript : MonoBehaviour {
    public float speed = 30f;

    void Update() {
        if(!CreatePlanet.pause)
            transform.Rotate(0, speed * Time.deltaTime, 0, Space.Self);
    }
}