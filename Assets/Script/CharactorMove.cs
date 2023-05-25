using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public float speed;
    public bool isRoute1;
    public bool isRoute2;
    public bool isRoute3;
    public bool rayHit;
    private Vector3 moveTarget;

    void Start()
    {
        speed = 0.1f;
        target1 = GameObject.Find("collider1");
        target2 = GameObject.Find("collider2");
        target3 = GameObject.Find("collider3");
        isRoute1 = false;
        isRoute2 = false;
        isRoute3 = false;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RayCheck();
        }

        if(rayHit)
        {
            CharaMove();
        }

        
    }

    private void CharaMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveTarget, speed);
    }

    private void RayCheck()
    {
        Ray ray = new Ray();
        RaycastHit hit = new RaycastHit();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 mousePos = Input.mousePosition;

        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity) && hit.collider == target1.GetComponent<Collider>())
        {
            rayHit = true;
            if(isRoute1 == false)
            {
                moveTarget = target1.transform.position;
                isRoute1 = true;
            }
        }

        else if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity) && hit.collider == target2.GetComponent<Collider>())
        {
            rayHit = true;
            if(isRoute1 == true && isRoute2 == false)
            {
                moveTarget = target2.transform.position;
                isRoute2 = true;
            }
        }

        else if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity) && hit.collider == target3.GetComponent<Collider>())
        {
            rayHit = true;
            if (isRoute2 == true && isRoute3 == false)
            {
                moveTarget = target3.transform.position;
                isRoute3 = true;
            }
        }

        else
        {
            rayHit = false;
        }
    }
}
