using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private instrument_Randomer manager;
    private Spaceship_Controllor spaceship;
    private string facing_direction;
    void Start()
    {
        spaceship = FindNearestWithTag("spaceship").GetComponent<Spaceship_Controllor>();
        manager = FindNearestWithTag("manager").GetComponent<instrument_Randomer>();

    }

    // Update is called once per frame
    void Update()
    {
        MoveMap();
        
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


    void MoveMap()
    {
        if (manager.CheckAnswer() == "forward")
        {
            if (spaceship.GiveDirection() == "up")
            {
                this.transform.position += new Vector3(0, -1, 0);
                manager.SetCheckingAnswerFalse();
                
            }
            if (spaceship.GiveDirection() == "left")
            {
                this.transform.position += new Vector3(1, 0, 0);
                manager.SetCheckingAnswerFalse();
            }
            if (spaceship.GiveDirection() == "right")
            {
                this.transform.position += new Vector3(-1, 0, 0);
                manager.SetCheckingAnswerFalse();
            }
            if (spaceship.GiveDirection() == "down")
            {
                this.transform.position += new Vector3(0, 1, 0);
                manager.SetCheckingAnswerFalse();
            }
            manager.ResetAudioSource();

        }
    }

   
}
