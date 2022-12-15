using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class CustomerController : MonoBehaviour
{
    public Customer customer;
    private NavMeshAgent _customerAgent;
    private Animator _customerAnimator;
    private Transform lookPos;

    private void Awake()
    {
        _customerAgent = GetComponent<NavMeshAgent>();
        _customerAnimator = GetComponent<Animator>();
    }

    public void SetPath(Transform counter, Transform lookPos)
    {
        this.lookPos = lookPos;
        _customerAgent.SetDestination(counter.position);
        _customerAgent.transform.LookAt(lookPos.position);
        _customerAnimator.SetTrigger("IsWalking");
    }

    private void Update()
    {
        CheckIfCustomerReachedCounter();
        CheckIfCustomerReachedEndPos();
    }

    private void CheckIfCustomerReachedEndPos()
    {
        if (!_customerAgent.pathPending && !_customerAgent.isStopped)
        {
            if (_customerAgent.remainingDistance <= 1f)
            {
                Debug.Log("Old customer reached pos");
                _customerAgent.isStopped = true;
                _customerAnimator.SetTrigger("IsIdle");
                Destroy(this.gameObject);
            }
        }
    }

    public void SendCustomerAway(Vector3 finalPosition)
    {
        _customerAgent.isStopped = false;
        _customerAgent.SetDestination(finalPosition);
        _customerAnimator.SetTrigger("IsWalking");
        Destroy(this.gameObject, 15f);
    }

    private void CheckIfCustomerReachedCounter()
    {
        if (!_customerAgent.pathPending && !_customerAgent.isStopped)
        {
            if (_customerAgent.remainingDistance <= 1f)
            {
                _customerAgent.isStopped = true;
                _customerAnimator.SetTrigger("IsIdle");
                transform.DOLookAt(lookPos.position, 1f);
            }
        }
    }
}