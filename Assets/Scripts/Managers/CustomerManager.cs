using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Managers
{
    public class CustomerManager : MonoBehaviour
    {
        public List<Customer> customerList;
        public int dailyCustomerCount;
        public CrimeList crimeList;
        public CustomerPrefabs customers;
        [SerializeField] private Transform counter;
        [SerializeField] private Transform lookPos;
        public List<Transform> spawnPoints;
        public List<Transform> endPoints;

        private NavMeshAgent _customerAgent;
        private Animator _customerAnimator;
        private GameObject _customer;

        public Customer currentCustomer;
        private List<Customer> oldCustomers;

        private void Update()
        {
            CheckIfCustomerReachedCounter();

            CheckIfOldCustomerIsAway();
        }

        private void CheckIfOldCustomerIsAway()
        {
            // foreach (var customer in oldCustomers)
            // {
            //     if
            // }
        }

        private void CheckIfCustomerReachedCounter()
        {
            if(_customerAgent==null) return;
            if (!_customerAgent.pathPending && !_customerAgent.isStopped)
            {
                if (_customerAgent.remainingDistance <= 1f)
                {
                    //  if (!_customerAgent.hasPath || _customerAgent.velocity.sqrMagnitude == 0f)
                    //  {
                    _customerAgent.isStopped = true;
                    _customerAnimator.SetTrigger("IsIdle");
                    _customer.transform.LookAt(lookPos.position);
                    // }
                }
            }
        }


        public Customer GetNewCustomer()
        {
            currentCustomer = CustomerGenerator();
            var index = GetRandomNumber(customers.customer.Count - 1);
            var spawnPointIndex = GetRandomNumber(spawnPoints.Count - 1);

            string crimes =
                currentCustomer.crimeCountDictionary.Keys.Aggregate<Crime, string>(null,
                    (current, crime) => current + crime.crime.ToString());
            string crimeCounts =
                currentCustomer.crimeCountDictionary.Values.Aggregate<int, string>(null,
                    (current, crime) => current + crime);

            Debug.Log(
                $"Customer created with Danger Level: {currentCustomer.dangerLevel} Crimes: {crimes} {crimeCounts}");
            _customer = Instantiate(customers.customer[index], spawnPoints[spawnPointIndex]);
            Debug.Log("Set is IsWalking");
            
            _customerAnimator = _customer.GetComponent<Animator>();
            _customerAnimator.SetTrigger("IsWalking");
            _customerAgent = _customer.GetComponent<NavMeshAgent>();
            _customerAgent.SetDestination(counter.position);

            return currentCustomer;
        }

        private Customer CustomerGenerator()
        {
            var customer = new Customer
            {
                crimeCountDictionary = new Dictionary<Crime, int>()
            };

            if (GetRandomNumber(10) > 7) customer.isWanted = true;

            var crimeCount = GetRandomNumber(5);
            for (int i = 0; i < crimeCount+1; i++)
            {
                var crimeIndex = GetRandomNumber(crimeList._crimeList.Count - 1);
                var crime = crimeList._crimeList[crimeIndex];
                var thisCrimeCount = GetRandomCrimeCount();
                if (!customer.crimeCountDictionary.ContainsKey(crime))
                {
                    customer.crimeCountDictionary.Add(crime, thisCrimeCount);
                    customer.dangerLevel += crime.dangerLevel * thisCrimeCount;
                    if (customer.isWanted) customer.dangerLevel *= 2;
                }
            }

            return customer;
        }

        private int GetRandomNumber(int limit)
        {
            return Random.Range(0, limit);
        }

        private int GetRandomCrimeCount()
        {
            int count = Random.Range(1, 15);
            if (count > 7) count = Random.Range(1, 10);
            if (count > 7) count =Random.Range(1, 10);
            if (count > 5) count =Random.Range(1, 15);

            return count;
        }

        public void SendCustomerAway()
        {
            _customerAgent.isStopped = false;
            int index = Random.Range(0, endPoints.Count - 1);
            _customerAgent.SetDestination(endPoints[index].position);
            _customerAnimator.SetTrigger("IsWalking");
            oldCustomers.Add(currentCustomer);
        }
    }
}