using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    public GameObject spaceship;
    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spaceshipRay();
    }

    void spaceshipRay()
    {
        RaycastHit2D spaceshipRay;

        spaceshipRay = Physics2D.Raycast(transform.position, spaceship.transform.position, Mathf.Infinity, layerMask);

        if (spaceshipRay)
        {
            print(spaceshipRay.point);
        }
    }
}
