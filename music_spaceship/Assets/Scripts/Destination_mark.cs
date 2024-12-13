using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination_mark : MonoBehaviour
{
    public Destination destination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion targetRotation = Quaternion.Euler(0, 0, destination.spaceshipRay());
        transform.rotation = targetRotation;
    }


}
