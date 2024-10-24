using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float SpeedX;
    public float SpeedY;
    public float SpeedZ;

    void Update()
    {
        transform.Rotate(360 * SpeedX * Time.deltaTime, 360 * SpeedY * Time.deltaTime, 360 * SpeedZ * Time.deltaTime);
    }
}
