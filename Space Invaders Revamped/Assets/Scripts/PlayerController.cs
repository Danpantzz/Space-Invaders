using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public GameObject bullet;

    public static bool extraLife = false;
    public static bool fasterShip = false;
    public static bool smallerShip = false;

    // Start is called before the first frame update
    void Start()
    {
        if (fasterShip)
        {
            speed = 15f;
        }
        if (smallerShip)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // movement
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0) transform.Translate(Vector2.right * speed * Time.deltaTime);
        else if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0) transform.Translate(Vector2.left * speed * Time.deltaTime);

        // can't go out of bounds
        if (transform.position.x > 23) transform.position = new Vector3(23f, transform.position.y, transform.position.z);
        if (transform.position.x < -23) transform.position = new Vector3(-23f, transform.position.y, transform.position.z);

        if (Input.GetButtonDown("Jump")) Fire();
    }

    private void Fire()
    {
        Debug.Log("Fire");
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1f, 0f), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            extraLife = false;
            fasterShip = false;
            smallerShip = false;

            Destroy(this.gameObject);
            SceneManager.LoadScene("MainMenu");
            SceneManager.UnloadSceneAsync("SpaceInvaders");
        }

        if (collision.gameObject.tag == "Enemy Bullet")
        {
            transform.position = new Vector2(0f, -9f);

            GameObject.FindGameObjectWithTag("UIManager").GetComponent<LifeCount>().LoseLife();
        }
    }
}
