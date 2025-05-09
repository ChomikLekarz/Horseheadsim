using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int punkty = 0;
    //private Collider2D coll;

    //private void Start()
    //{
    //    coll = GetComponent<Collider2D>();
    //}

    void FixedUpdate()
    {
        transform.position += Vector3.right;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            punkty++;
            Destroy(this.gameObject);
        }
    }
}
