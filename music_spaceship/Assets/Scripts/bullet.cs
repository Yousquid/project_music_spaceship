using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private float timer;
    private Vector2 direction;
    public Spaceship_Controllor spaceship;
    public bool hasShot = false;
    // Start is called before the first frame update
    void Start()
    {
        spaceship = FindNearestWithTag("spaceship").GetComponent<Spaceship_Controllor>();
        rigidbody = GetComponent<Rigidbody2D>();
        DirectionChangeBasedOnSpaceship();


    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.5f)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
            Destroy(gameObject);
        }
    }

    void DirectionChangeBasedOnSpaceship()
    {
        if (spaceship.GiveDirection() == "up")
        {
            rigidbody.velocity += Vector2.up * 1.5F;
        }
        if (spaceship.GiveDirection() == "down")
        {
            rigidbody.velocity += Vector2.down * 1.5F;
        }
        if (spaceship.GiveDirection() == "left")
        {
            this.transform.Rotate(0, 0, 90);
            this.transform.position += new Vector3(0, -0.4f, 0);
            rigidbody.velocity += Vector2.left * 1.5F;
        }
        if (spaceship.GiveDirection() == "right")
        {
            this.transform.Rotate(0, 0, -90);
            this.transform.position += new Vector3(0, -0.4f, 0);
            rigidbody.velocity += Vector2.right * 1.5F;
        }
    }

    GameObject FindNearestWithTag(string tag)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        GameObject nearestObject = null;
        float shortestDistance = Mathf.Infinity;
        Vector3 currentPosition = this.transform.position;

        foreach (GameObject obj in objectsWithTag)
        {
            float distanceToObj = Vector3.Distance(currentPosition, obj.transform.position);

            if (distanceToObj < shortestDistance)
            {
                shortestDistance = distanceToObj;
                nearestObject = obj;
            }
        }

        return nearestObject;
    }
}
