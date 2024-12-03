using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship_Controllor : MonoBehaviour
{
    private instrument_Randomer manager;
    private float facing_hor;
    private float facing_vert;
    private string facing_direction;
    void Start()
    {
        manager = FindNearestWithTag("manager").GetComponent<instrument_Randomer>();

    }

    // Update is called once per frame
    void Update()
    {
        moveSpaceship();
        RotationFix();
        DirectionDetect();
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


    void moveSpaceship()
    {
        if (manager.CheckAnswer() == "forward")
        {
            this.transform.position += new Vector3(facing_hor, facing_vert, 0);
            manager.SetCheckingAnswerFalse();
        }
        if (manager.CheckAnswer() == "left")
        {
            this.transform.Rotate(0,0,90);
            manager.SetCheckingAnswerFalse();
        }
        if (manager.CheckAnswer() == "right")
        {
            this.transform.Rotate(0, 0, -90);
            manager.SetCheckingAnswerFalse();
        }
        if (manager.CheckAnswer() == "shoot")
        {

        }
        if (manager.CheckAnswer() == "error")
        {
            manager.SetCheckingAnswerFalse();
        }
    }

    void DirectionDetect()
    {
        if (this.transform.rotation.z == 90)
        {
            facing_hor = -1;
            facing_vert = 0;
        }
        if (this.transform.rotation.z == -90)
        {
            facing_hor = 1;
            facing_vert = 0;
        }
        if (this.transform.rotation.z == 0)
        {
            facing_vert = 1;
            facing_hor = 0;
        }
        if (this.transform.rotation.z == 180 || this.transform.rotation.z == -180)
        {
            facing_vert = -1;
            facing_hor = 0;
        }

    }
    void RotationFix()
    {
        if (this.transform.rotation.z >= 270)
        {
            this.transform.Rotate(0, 0, -360);
        }
        if (this.transform.rotation.z <= -270)
        {
            this.transform.Rotate(0, 0, 360);
        }
    }
}
