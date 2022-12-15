using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerInfo : MonoBehaviour
{
    [SerializeField] private int starCount;
    [SerializeField] private List<Image> stars = new();
    [SerializeField] private Sprite starImage;
    [SerializeField] private Sprite oldStarImage;

    public void InitCustomerInfo(Customer customer)
    {
        ResetStarImages();

        starCount = SetStarCount(customer);

        for (int i = 0; i < starCount; i++)
        {
            stars[i].sprite = starImage;
        }

        gameObject.SetActive(false);
    }

    private void ResetStarImages()
    {
        for (int i = 0; i < starCount; i++)
        {
            stars[i].sprite = oldStarImage;
        }
    }

    private int SetStarCount(Customer customer)
    {
        var danger = customer.dangerLevel;
        Debug.Log("Current danger level" + danger);
        if (danger > 100) starCount = 1;
        if (danger > 1000) starCount = 2;
        if (danger > 5000) starCount = 3;
        if (danger > 10000) starCount = 4;
        if (danger > 20000) starCount = 5;

        return starCount;
    }
}