using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Vector3 Vec;
    public float jumpForce = 3;
    float velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vec = transform.localPosition;
        Vec.y += Input.GetAxis("Jump") * Time.deltaTime * 20;
        Vec.x += Input.GetAxis("Horizontal") * Time.deltaTime * 20;
        Vec.z += Input.GetAxis("Vertical") * Time.deltaTime * 20;
        transform.localPosition = Vec;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(Vector3.right * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(Vector3.left * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            velocity = jumpForce;

        }
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
     
    }
}
