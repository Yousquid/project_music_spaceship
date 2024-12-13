using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destination_mark : MonoBehaviour
{
    public Destination destination;
    public GameObject mark;
    public float timer;
    public bool DecreaseOrIncrease = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion targetRotation = Quaternion.Euler(0, 0, destination.spaceshipRay());
        transform.rotation = targetRotation;

        timer += Time.deltaTime;

        if (timer >= 1f && DecreaseOrIncrease)
        {
            mark.SetActive(false);
            DecreaseOrIncrease = false;
            timer = 0f;
        }


        if (!DecreaseOrIncrease && timer >= 0.2f)
        {
            mark.SetActive(true);
            DecreaseOrIncrease = true;
            timer = 0f;
        }
    }


}
