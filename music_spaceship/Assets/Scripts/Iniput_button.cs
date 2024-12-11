using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iniput_button : MonoBehaviour
{
    public instrument_Randomer manager;
    public Audio_Manager audio_manager;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        manager = FindNearestWithTag("manager").GetComponent<instrument_Randomer>();
        audio_manager = FindNearestWithTag("manager").GetComponent<Audio_Manager>();

    }

    // Update is called once per frame
    void Update()
    {
        buttonClickDetection();
       
    }


    void buttonClickDetection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audio_manager.playButtonSound();

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                //for (int i = 0; i < 5; i++)
                //{
                //    if (manager.playerInputList[i] != "0")
                //    {
                //        continue;
                //    }
                //    else if (manager.playerInputList[i] == "0")
                //    {
                //        return;
                //    }
                //}

                anim.SetTrigger("Press");
                manager.resetInputList();

            }
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
    void recordPlayerInput()
    { 
    
    }

}
