using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ƍN�̃L�����N�^�[�ɂ��̂܂܃A�^�b�`����
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
        //Unity��ŕ����]������ꏊ��collider1�`5�����Ԃɔz�u����B
        //collider�̖��O��ς����Ⴄ�Ɠ����Ȃ��̂Œ��ӁB
        //�ړ����́u�X�^�[�g�ʒu�� 1(�K�i����O) �� 2(�K�i����) �� 3(�K�i�㉱�̎�O) �� 4(���̏ꏊ) �� 5(�g�C���̏ꏊ)�v
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
