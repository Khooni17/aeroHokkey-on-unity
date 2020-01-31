using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class puck : MonoBehaviour
{
    // Start is called before the first frame update
    private float minZ = -5.1f, maxZ = 4.44f, currZ;
    private float defX = -0.46f, defY = 1.313f, defZ = -0.99f;
    public int count1, count2;

    void Start()
    {
        MeshRenderer renderer = GameObject.Find("Table").GetComponent<MeshRenderer>();

        float minx = renderer.bounds.min.x;
        float maxx = renderer.bounds.max.x;
        float minz = renderer.bounds.min.z;
        float maxz = renderer.bounds.max.z;

        float midx = minx + (maxx - minx) / 2;
        float midz = minz + (maxz - minz) / 2;
        count1 = 0;
        count2 = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // голы
        currZ = transform.position.z;
        if(currZ <= minZ)
        {
            count1++;
            print(count1);
            this.GetComponents<AudioSource>()[1].Play();
            // обнуление скорости
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, this.GetComponent<Rigidbody>().velocity.y, 0);
            transform.position = new Vector3(defX, defY+15, defZ);


             //Smoothly tilts a transform towards a target rotation.
            float smooth = 5.0f;
            float tiltAngle = 160.0f;
            float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
            float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
            Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
             //Dampen towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }

        if (currZ >= maxZ)
        {
            count2++;
            print(count2);
            this.GetComponents<AudioSource>()[1].Play();
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, this.GetComponent<Rigidbody>().velocity.y, 0);
            transform.position = new Vector3(defX, defY + 15, defZ);
        }

        GameObject.Find("Count").GetComponent<UnityEngine.UI.Text>().text = "  Счет: \n     "
            +count1.ToString() + "\n     " + count2.ToString();

    }



    void OnCollisionEnter(Collision collision)
    {
        // отталкивание
        if(collision.gameObject.name == "Capsule" ||
           collision.gameObject.name == "Capsule (1)")
        {
            Vector3 force = collision.contacts[0].normal;
            force.y = 0;
            gameObject.GetComponent<Rigidbody>().AddForceAtPosition(force * 600, transform.position);
        } else if (collision.gameObject.name == "Cube" ||
                   collision.gameObject.name == "Cube (4)" ||
                   collision.gameObject.name == "Cube (5)" ||
                   collision.gameObject.name == "Cube (1)" ||
                   collision.gameObject.name == "Cube (3)" ||
                   collision.gameObject.name == "Cube (2)")
        {

            Vector3 force = collision.contacts[0].normal;
            force.y = 0;
            gameObject.GetComponent<Rigidbody>().AddForceAtPosition(force * 300, transform.position);

            // свет при столкновении
            MeshRenderer renderer = GameObject.Find("Table").GetComponent<MeshRenderer>();
            float minx = renderer.bounds.min.x;
            float maxx = renderer.bounds.max.x;
            float minz = renderer.bounds.min.z;
            float maxz = renderer.bounds.max.z;
            GameObject lightGameObject = new GameObject("The Light");
            Light lightComp = lightGameObject.AddComponent<Light>();
            lightComp.intensity = 25;
            lightGameObject.transform.position = this.transform.position;

            if (this.transform.position.z <= 0.06)
            {
                lightComp.color = Color.red;
            } else
            {
                lightComp.color = Color.blue;
            }


            this.GetComponent<AudioSource>().Play();
            Destroy(lightGameObject, 0.09f);

        }
    }

    

}
