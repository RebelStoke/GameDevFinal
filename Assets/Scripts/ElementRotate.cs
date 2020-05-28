using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ElementRotate : MonoBehaviour
{
    void Start()
    {
        transform.Rotate(90, 0, 0, Space.World);
    }

    void Update()
    {
        transform.Rotate(0, 360 * Time.deltaTime, 0, Space.World);
    }
}
