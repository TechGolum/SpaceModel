using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveVector3
{
    [SerializeField]
    public float x, y, z;
    public SaveVector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}
