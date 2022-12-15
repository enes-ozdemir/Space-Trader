using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CustomerPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI offerText;
        [SerializeField] private TextMeshProUGUI crimeList;
        [SerializeField] private CustomerInfo _customerInfo;

        public void UpdateOfferText(int offer, int cost)
        {
            if (offer == 0) offer = 1;
            var value = ((float)(offer - cost) / cost) * 100;
            //todo change text color according to value
            offerText.text = $"Offer: {offer} \n Profit: % {(int)value}";
        }

        public void UpdateCrimeList(Customer customer)
        {
            _customerInfo.InitCustomerInfo(customer);
            
            string crimeListText = "Crime List:\n";
            foreach (var crime in customer.crimeCountDictionary)
            {
                crimeListText += $"{crime.Key.crime} X{crime.Value} \n";
            }

            crimeList.text = crimeListText;
        }

        public void InfoBought()
        {
            _customerInfo.gameObject.SetActive(true);
        }
    }
}