using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class counter : MonoBehaviour
{
    private int count;
    public GUIText countText;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        countText.text = "Count : " + 2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
