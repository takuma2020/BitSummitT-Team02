using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CS_FollowPlayer : MonoBehaviour
{
    GameObject PlayerCharacter_Head;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCharacter_Head = GameObject.FindGameObjectWithTag("Head");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PlayerCharacter_Head.transform.position;
    }
}
