using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    [SerializeField] private DoorController[] doors;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (DoorController d in doors)
        {
            anim.SetBool("Activated", true);
            d.OpenDoor();
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        foreach (DoorController d in doors)
        {
            anim.SetBool("Activated", false);
            d.CloseDoor();
        }
    }
}
