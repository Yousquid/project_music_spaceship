using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Destination : MonoBehaviour
{
    public GameObject spaceship;
    public LayerMask layerMask;
    private Vector2 vertex;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        vertex = new Vector2(spaceship.transform.position.x, spaceship.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, spaceship.transform.position);
        if (distance <= 0.1f)
        {
            text.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public float spaceshipRay()
    {
        RaycastHit2D spaceshipRay;

        Vector2 baseLine;

        Vector2 hitLine;

        Vector2 direction = (spaceship.transform.position - transform.position).normalized;

        spaceshipRay = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, layerMask);

        if (spaceshipRay)
        {
            baseLine = new Vector2(spaceship.transform.position.x, 0.46f) - vertex;
            hitLine = spaceshipRay.point - vertex;
            return Vector2.SignedAngle(baseLine, hitLine);
        }
        else return 0f;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "spaceship")
        {
            
        }
    }



}
