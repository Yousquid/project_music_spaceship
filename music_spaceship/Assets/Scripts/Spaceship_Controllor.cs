using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship_Controllor : MonoBehaviour
{
    private instrument_Randomer manager;
    public string facing_direction;
    float zAngle;
    public GameObject bullet;
    public float distanceCheck = 1.5f;
    public LayerMask layerMask;
    private Vector2 direction;
    public Audio_Manager audio_manager;
    void Start()
    {
        manager = FindNearestWithTag("manager").GetComponent<instrument_Randomer>();
        audio_manager = FindNearestWithTag("manager").GetComponent<Audio_Manager>();
        facing_direction = "up";
        zAngle = this.transform.eulerAngles.z;
        direction = new Vector2(0, 1);

    }

    // Update is called once per frame
    void Update()
    {
        moveSpaceship();
        RotationFix();
        DirectionDetect();

        print(GiveDirection());

        if (Input.GetKeyDown(KeyCode.M))
        {
           
            print(isObstacleFront());
            print(direction);
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
        if (manager.CheckAnswer() == "left" || Input.GetKeyDown(KeyCode.Q))
        {
            this.transform.Rotate(0,0,90);
            direction += new Vector2(-1, 0);
            audio_manager.playSpaceshipTurn();
            manager.SetCheckingAnswerFalse();
            manager.ResetAudioSource();
        }
        if (manager.CheckAnswer() == "right" || Input.GetKeyDown(KeyCode.E))
        {
            this.transform.Rotate(0, 0, -90);
            direction += new Vector2(1, 0);
            audio_manager.playSpaceshipTurn();
            manager.SetCheckingAnswerFalse();
            manager.ResetAudioSource();
        }
        if (manager.CheckAnswer() == "shoot" || Input.GetKeyDown(KeyCode.I))
        {
            Instantiate(bullet);
            audio_manager.playSpaceshipShoot();
            manager.SetCheckingAnswerFalse();
            manager.ResetAudioSource();
        }
        if (manager.CheckAnswer() == "error" && manager.detectIfInputListIsFull())
        {
            audio_manager.playWrongSFX();
            manager.SetCheckingAnswerFalse();
        }
    }

    void DirectionDetect()
    {
        if (direction == new Vector2 (1,1) || direction == new Vector2(-1, -1))
        {
            facing_direction = "right";
           
        }
        else if (direction == new Vector2 (-1,1) || direction == new Vector2 (1,-1))
        {
            facing_direction = "left";
            
        }
        else if (direction == new Vector2 (0,1))
        {
            facing_direction = "up";
            
        }
        else if (direction == new Vector2 (0,-1))
        {
            facing_direction = "down";
            
        }

    }
    void RotationFix()
    {
        if (direction.y == 1)
        {
            if (direction.x == -2 )
            {
                direction += new Vector2(2, -2);
            }
            if (direction.x == 2)
            {
                direction += new Vector2(-2, -2);
            }
        }
        else if (direction.y == -1)
        {
            if (direction.x == -2)
            {
                direction += new Vector2(2, 2);
            }
            if (direction.x == 2)
            {
                direction += new Vector2(-2, 2);
            }
        }
       
    }

    public string GiveDirection()
    {
        return facing_direction;
    }

    public bool isObstacleFront()
    {
        RaycastHit2D frontRay;

        frontRay = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), distanceCheck,layerMask);

        if (frontRay)
        {
            return true;
        }
        else return false;
    }
}
