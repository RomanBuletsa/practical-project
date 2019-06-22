using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private bool l = false;
    private bool r = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0f) l = true;
        if (Input.GetAxis("Horizontal") < 0f) r = true;
    }

    void FixedUpdate()
    {
        if (l)
        {
            transform.Translate(Vector3.right * 0.2f);
            l = false;
        }

        if (r)
        {
            transform.Translate(Vector3.left * 0.2f);
            r = false;
        }
    }
}
