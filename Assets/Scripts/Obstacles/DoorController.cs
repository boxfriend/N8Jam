using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen = false;
    private Rigidbody2D body;
    private Vector2 startPos;
    [SerializeField] private float speed;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isOpen)
        {
            //transform.position = Vector2.MoveTowards(transform.position, startPos - new Vector2(0,4), 10 * Time.deltaTime);
            body.MovePosition(Vector2.MoveTowards(transform.position, startPos - new Vector2(0, 4), speed * Time.deltaTime));
        } else
        {
            //transform.position = Vector2.MoveTowards(transform.position, startPos, 10 * Time.deltaTime);
            body.MovePosition(Vector2.MoveTowards(transform.position, startPos, speed * Time.deltaTime));
        }


    }

    public void OpenDoor()
    {
        isOpen = true;
    }

    public void CloseDoor()
    {
        isOpen = false;
    }
}
