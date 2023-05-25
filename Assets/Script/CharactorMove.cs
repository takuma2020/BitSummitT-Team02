using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;
    public float speed;
    public bool isTouch;
    public bool isRoute1;
    public bool isRoute2;
    public bool isRoute3;

    void Start()
    {
        speed = 0.1f;
        target1 = GameObject.Find("MousePoint");
        target2 = GameObject.Find("collider1");
        target3 = GameObject.Find("collider2");
        target4 = GameObject.Find("collider3");
        isTouch = false;
        isRoute1 = false;
        isRoute2 = false;
        isRoute3 = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MousePoint")
        {
            isTouch = true;
        }

        if (collision.gameObject.name == "collder1")
        {
            isRoute1 = true;
        }

        if (collision.gameObject.name == "collder2")
        {
            isRoute2 = true;
        }

        if (collision.gameObject.name == "collder3")
        {
            isRoute3 = true;
        }
    }

    void Update()
    {
        if (isTouch == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target1.transform.position, speed);
        }
    }
}
