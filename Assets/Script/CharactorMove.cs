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
    public GameObject target5;
    public float speed;
    public bool isRoute1;
    public bool isRoute2;
    public bool isRoute3;
    public bool isRotate;
    public bool rayHit;
    private Vector3 moveTarget;
    private Vector3 startPlace;

    void Start()
    {
        speed = 0.1f;
        target1 = GameObject.Find("collider1");
        target2 = GameObject.Find("collider2");
        target3 = GameObject.Find("collider3");
        target4 = GameObject.Find("collider4");
        target5 = GameObject.Find("collider5");
        isRoute1 = false;
        isRoute2 = false;
        isRoute3 = false;
        isRotate = false;
        startPlace = this.transform.position;
        rayHit = false;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RayCheck();
        }

        if(rayHit)
        {
            CharaMove(moveTarget);
        }

        
    }

    private void CharaMove(Vector3 moveTarget)
    {
        transform.position = Vector3.MoveTowards(transform.position, moveTarget, speed);
    }

    private void RayCheck()
    {
        Ray ray = new Ray();
        RaycastHit hit = new RaycastHit();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 mousePos = Input.mousePosition;

        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity) && hit.collider == target4.GetComponent<Collider>())
        {
            rayHit = true;
            if(isRoute1 == false)
            {
                transform.Rotate(0, -90, 0);
                moveTarget = target1.transform.position;
                isRotate = false;
                
                

                if (this.transform.position == target1.transform.position)
                {
                    transform.Rotate(0, -90, 0);
                    isRotate = true;
                    if (isRotate)
                    {
                        moveTarget = target2.transform.position;
                        isRotate = false;
                    }
                }

                if (this.transform.position == target2.transform.position)
                {
                    transform.Rotate(0, -90, 0);
                    isRotate = true;
                    if (isRotate)
                    {
                        moveTarget = target3.transform.position;
                        isRotate = false;
                    }
                }

                if (this.transform.position == target3.transform.position)
                {
                    moveTarget = target4.transform.position;
                    isRoute1 = true;
                }
            }
        }

        else if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity) && hit.collider == target5.GetComponent<Collider>())
        {
            rayHit = true;
            if(isRoute1 == false && this.transform.position == startPlace)
            {
                transform.Rotate(0, -90, 0);
                isRotate = true;
                if (isRotate)
                {
                    moveTarget = target5.transform.position;
                    isRotate = false;
                }
                isRoute2 = true;
            }

            if(isRoute1 == true && this.transform.position == target4.transform.position)
            {
                moveTarget = target3.transform.position;
            }

            if (isRoute1 == true && this.transform.position == target3.transform.position)
            {
                moveTarget = target2.transform.position;
            }

            if (isRoute1 == true && this.transform.position == target2.transform.position)
            {
                transform.Rotate(0, 90, 0);
                isRotate = true;
                if (isRotate)
                {
                    moveTarget = target1.transform.position;
                    isRotate = false;
                }
            }

            if (isRoute1 == true && this.transform.position == target1.transform.position)
            {
                transform.Rotate(0, -90, 0);
                isRotate = true;
                if (isRotate)
                {
                    moveTarget = target5.transform.position;
                    isRotate = false;
                }
                isRoute2 = true;
            }

        }

        else
        {
            rayHit = false;
        }
    }
}
