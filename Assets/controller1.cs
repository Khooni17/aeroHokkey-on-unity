using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller1 : MonoBehaviour
{
    float minx;
    float maxx;
    float minz;
    float maxz;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer renderer = GameObject.Find("Table").GetComponent<MeshRenderer>();
        minx = renderer.bounds.min.x;
        maxx = renderer.bounds.max.x;
        minz = renderer.bounds.min.z;
        maxz = renderer.bounds.max.z;
    }

    // Update is called once per frame
    void FixedUpdate()  
    {
        transform.position = new Vector3(transform.position.x, 1.38f, transform.position.z);
        // перемещение
        if (Input.GetKey(KeyCode.W))
        {
            if(transform.position.z <= (minz + (maxz-minz)/2 - 1 ))
            {
                transform.position += Vector3.forward * 0.1f;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if(transform.position.z >= minz+0.4)
            {
                transform.position -= Vector3.forward * 0.1f;
            }

        }
        if (Input.GetKey(KeyCode.D))
        {
            if(transform.position.x <= maxx-1)
            {
                transform.position += transform.right * 0.1f;
            }

        }
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x >= minx + 1)
            {
                transform.position -= transform.right * 0.1f;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        //        collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000, collision.contacts[0].point, 100);
    }
}
