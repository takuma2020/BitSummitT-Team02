using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public float speed;
    public bool isTouch;
    public bool isRoute1;
    public bool isRoute2;
    public bool isRoute3;

    void Start()
    {
        speed = 0.1f;
        target = GameObject.Find("MousePoint");
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
    }

    void Update()
    {
        if (isTouch == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }
    }
}
