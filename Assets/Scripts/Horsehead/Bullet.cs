using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    void FixedUpdate()
    {
        transform.position += Vector3.right;
    }
}
