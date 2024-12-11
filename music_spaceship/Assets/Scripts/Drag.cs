 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    Vector2 mousePos;
    Vector2 distance;
    Rigidbody2D rb;
    public Audio_Manager audio_manager;

    private bool isDown = false;
    private bool isDrag = false;
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
        isDrag = true;
        if (isDown)
        {
            audio_manager.playStickOffSound();
            isDown = false;
        }
        distance = new Vector2(transform.position.x, transform.position.y) - mousePos;
    }

    private void OnMouseDrag()
    {
        isDown = true;
        if (isDrag)
        {
            audio_manager.playStickOnSound();
            isDrag = false;
        }

        transform.position = mousePos + distance;
    }
}
