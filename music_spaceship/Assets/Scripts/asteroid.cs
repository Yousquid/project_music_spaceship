using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    public Audio_Manager audio_manager;
    void Start()
    {
        audio_manager = FindNearestWithTag("manager").GetComponent<Audio_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            audio_manager.playAesteroidSound();
            Destroy(gameObject);
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
