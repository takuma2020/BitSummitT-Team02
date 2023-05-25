using UnityEngine;
using UnityEngine.AI;

public class CS_Move : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                MoveTo(hit.point);
            }
        }


        animator.SetFloat("MoveSpeed", agent.velocity.magnitude);
    }

    private void MoveTo(Vector3 destination)
    {
        if (agent.enabled)
        {
            agent.destination = destination;
        }
    }
}