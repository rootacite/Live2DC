using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
