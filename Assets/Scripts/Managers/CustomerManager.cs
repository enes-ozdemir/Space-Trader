using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class CustomerManager : MonoBehaviour
    {
        public CrimeList crimeList;
        public CustomerPrefabs customers;

        public List<Transform> spawnPoints;
        public List<Transform> endPoints;

        public Customer currentCustomer;
        public CustomerController currentCustomerController;
        private List<CustomerController> _oldCustomers = new();

        [SerializeField] public Transform counter;
        [SerializeField] public Transform lookPos;

        public void SendCurrentCustomerAway()
        {
            int index = Random.Range(0, endPoints.Count - 1);
            var finalPosition = endPoints[index].position;
            _oldCustomers.Add(currentCustomerController);
            currentCustomerController.SendCustomerAway(finalPosition);
        }

        public void GetNewCustomer()
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
            var customerGameObject = Instantiate(customers.customer[index], spawnPoints[spawnPointIndex]);
            currentCustomerController = customerGameObject.GetComponent<CustomerController>();
            currentCustomerController.SetPath(counter, lookPos);
            currentCustomerController.customer = currentCustomer;
        }

        private Customer CustomerGenerator()
        {
            var customer = new Customer
            {
                crimeCountDictionary = new Dictionary<Crime, int>()
            };

            if (GetRandomNumber(10) > 7) customer.isWanted = true;

            var crimeCount = GetRandomNumber(5);
            for (int i = 0; i < crimeCount + 1; i++)
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
            if (count > 7) count = Random.Range(1, 10);
            if (count > 5) count = Random.Range(1, 15);

            return count;
        }
    }
}