using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guidebook_on : MonoBehaviour
{
    public Audio_Manager audio_manager;
    public GameObject guidebook;
    // Start is called before the first frame update
    void Start()
    {
        
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
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                audio_manager.playGuidebookSound();
                if (this.gameObject.layer == 12)
                guidebook.SetActive(true);
                if (this.gameObject.layer == 13)
                    guidebook.SetActive(false);
            }
        }
    }
}
