using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//家康のキャラクターにそのままアタッチする
public class IeyasuMove : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;
    public GameObject target5;
    public float speed;
    public bool isRoute1;
    public bool isRoute2;
    public bool isBucket;
    public bool rayHit;
    public bool isToilet;
    private Vector3 moveTarget;
    private Vector3 startPlace;

    // Start is called before the first frame update
    void Start()
    {
        //Unity上で方向転換する場所にcollider1～5を順番に配置する。
        //colliderの名前を変えちゃうと動かないので注意。
        //移動順は「スタート位置→ 1(階段下手前) → 2(階段下奥) → 3(階段上桶の手前) → 4(桶の場所) → 5(トイレの場所)」
        speed = 0.03f;
        target1 = GameObject.Find("collider1");
        target2 = GameObject.Find("collider2");
        target3 = GameObject.Find("collider3");
        target4 = GameObject.Find("collider4");
        target5 = GameObject.Find("collider5");
        isRoute1 = false;
        isRoute2 = false;
        isToilet = false;
        isBucket = false;
        startPlace = this.transform.position;
        rayHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RayCheck();
        }

        if(rayHit)
        {
            CharaMove(TargetChange());
        }
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
            isBucket = true;
        }

        else if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity) && hit.collider == target5.GetComponent<Collider>())
        {
            rayHit = true;
            isToilet = true;
        }

        else
        {
            rayHit = false;
        }
    }

    private void CharaMove(Vector3 Target)
    {
        transform.position = Vector3.MoveTowards(this.transform.position, Target, speed);
    }

    private Vector3 TargetChange()
    {
        if(isBucket != isRoute1)
        {
            if(this.transform.position == startPlace)
            {
                transform.Rotate(0, -90, 0);
                moveTarget = target1.transform.position;
            }
        
            if(this.transform.position == target1.transform.position)
            {
                transform.Rotate(0, -90, 0);
                moveTarget = target2.transform.position;
            }
        
            if(this.transform.position == target2.transform.position)
            {
                transform.Rotate(0, -90, 0);
                moveTarget = target3.transform.position;
            }
        
            if(this.transform.position == target3.transform.position)
            {
                moveTarget = target4.transform.position;
            }
        
            if(this.transform.position == target4.transform.position)
            {
                isRoute1 = true;
            }
        }
        
        if(isToilet)
        {
            if(this.transform.position == startPlace)
            {
                transform.Rotate(0, -90, 0);
                moveTarget = target5.transform.position;
            }

            if(isRoute1)
            {
                if(this.transform.position == target4.transform.position)
                {
                    transform.Rotate(0, -180, 0);
                    moveTarget = target3.transform.position;
                }

                if(this.transform.position == target3.transform.position)
                {
                    moveTarget = target2.transform.position;
                }

                if(this.transform.position == target2.transform.position)
                {
                    transform.Rotate(0, 90, 0);
                    moveTarget = target1.transform.position;
                }

                if(this.transform.position == target1.transform.position)
                {
                    transform.Rotate(0, -90, 0);
                    moveTarget = target5.transform.position;
                }

                if(this.transform.position == target5.transform.position)
                {
                    isRoute2 = true;
                }
            }
        }
        
        return moveTarget;
    }
}
