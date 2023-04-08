using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public GameObject bullet;
    

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

        // can't go out of bounds
        if (transform.position.x > 25) transform.position = new Vector3(25f, transform.position.y, transform.position.z);
        if (transform.position.x < -25) transform.position = new Vector3(-25f, transform.position.y, transform.position.z);

        if (Input.GetButtonDown("Jump")) Fire();
    }

    private void Fire()
    {
        Debug.Log("Fire");
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1f, 0f), Quaternion.identity);
    }
}
