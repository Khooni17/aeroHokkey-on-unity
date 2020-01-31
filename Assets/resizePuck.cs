using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resizePuck : MonoBehaviour
{
    double valueBar;

    public void Start()
    {

    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            valueBar = GameObject.Find("Scrollbar").GetComponent<Scrollbar>().value;
            Vector3 oldSize = GameObject.Find("puck").GetComponent<Transform>().localScale;
            oldSize.x = oldSize.x *  (1 - (float)valueBar);
            oldSize.z = oldSize.z * (1 - (float)valueBar);
            float koeff = 0.7f;
            Vector3 newSize = new Vector3((float)valueBar+ koeff,
                                          oldSize.y,
                                          (float)valueBar+koeff);
            GameObject.Find("puck").GetComponent<Transform>().localScale = newSize;
            print(oldSize.x + "    " + valueBar + "    " + newSize.x );
        }

    }

}
