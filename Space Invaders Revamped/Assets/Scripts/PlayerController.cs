using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // movement
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0) transform.Translate(Vector2.right * speed * Time.deltaTime);
        else if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0) transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x > 8.35) transform.position = new Vector3(8.35f, transform.position.y, transform.position.z);
        if (transform.position.x < -8.35) transform.position = new Vector3(-8.35f, transform.position.y, transform.position.z);
    }
}
