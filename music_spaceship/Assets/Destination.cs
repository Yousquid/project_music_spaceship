using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    public GameObject spaceship;
    public LayerMask layerMask;
    private Vector2 vertex;
    // Start is called before the first frame update
    void Start()
    {
        vertex = new Vector2(spaceship.transform.position.x, spaceship.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float spaceshipRay()
    {
        RaycastHit2D spaceshipRay;

        Vector2 baseLine;

        Vector2 hitLine;

        Vector2 direction = (spaceship.transform.position - transform.position).normalized;

        spaceshipRay = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, layerMask);

        if (spaceshipRay)
        {
            baseLine = new Vector2(spaceship.transform.position.x, 0.46f) - vertex;
            hitLine = spaceshipRay.point - vertex;
            return Vector2.SignedAngle(baseLine, hitLine);
        }
        else return 0f;
    }

        
}
