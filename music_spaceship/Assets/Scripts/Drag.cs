 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    Vector2 mousePos;
    Vector2 distance;
    Rigidbody2D rb;
    public Audio_Manager audio_manager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


    }

    private void OnMouseDown()
    {
        audio_manager.playStickOffSound();
        distance = new Vector2(transform.position.x, transform.position.y) - mousePos;
    }

    private void OnMouseDrag()
    {
        audio_manager.playStickOnSound();

        transform.position = mousePos + distance;
    }
}
