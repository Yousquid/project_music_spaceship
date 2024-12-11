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

        if (timer >= 1.5f)
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
            rigidbody.velocity += Vector2.up;
        }
        if (spaceship.GiveDirection() == "down")
        {
            rigidbody.velocity += Vector2.down;
        }
        if (spaceship.GiveDirection() == "left")
        {
            rigidbody.velocity += Vector2.left;
        }
        if (spaceship.GiveDirection() == "right")
        {
            rigidbody.velocity += Vector2.right;
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
