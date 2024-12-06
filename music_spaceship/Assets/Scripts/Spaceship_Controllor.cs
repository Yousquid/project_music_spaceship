using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship_Controllor : MonoBehaviour
{
    private instrument_Randomer manager;
    private string facing_direction;
    float zAngle;

    void Start()
    {
        manager = FindNearestWithTag("manager").GetComponent<instrument_Randomer>();
        facing_direction = "up";
        zAngle = this.transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        moveSpaceship();
        RotationFix();
        DirectionDetect();

        if (Input.GetKeyDown(KeyCode.M))
        {
            print(GiveDirection());
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


    void moveSpaceship()
    {
        if (manager.CheckAnswer() == "forward")
        {

        }
        if (manager.CheckAnswer() == "left" )
        {
            this.transform.Rotate(0,0,90);
            manager.SetCheckingAnswerFalse();
            manager.ResetAudioSource();
        }
        if (manager.CheckAnswer() == "right" )
        {
            this.transform.Rotate(0, 0, -90);
            manager.SetCheckingAnswerFalse();
            manager.ResetAudioSource();
        }
        if (manager.CheckAnswer() == "shoot")
        {
            manager.ResetAudioSource();
        }
        if (manager.CheckAnswer() == "error")
        {
            manager.SetCheckingAnswerFalse();
        }
    }

    void DirectionDetect()
    {
        if (this.transform.eulerAngles.z == 90)
        {
            facing_direction = "left";
        }
        if (this.transform.eulerAngles.z == 270)
        {
            facing_direction = "right";
        }
        if (this.transform.eulerAngles.z == 0)
        {
            facing_direction = "up";
        }
        if (this.transform.eulerAngles.z == 180 || this.transform.eulerAngles.z == -180)
        {
            facing_direction = "down";
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

    public string GiveDirection()
    {
        return facing_direction;
    }
}
