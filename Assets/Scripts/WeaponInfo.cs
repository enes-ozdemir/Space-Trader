using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI weaponTypeText;
    [SerializeField] private int starCount;
    [SerializeField] private List<Image> stars = new();
    [SerializeField] private Sprite starImage;
    [SerializeField] private Sprite oldStarImage;

    public void InitWeaponInfo(WeaponValues weaponValues)
    {
        ResetStarImages();

        weaponTypeText.text = weaponValues.weaponType.ToString();
        starCount = SetStarCount(weaponValues);

        for (int i = 0; i < starCount; i++)
        {
            stars[i].sprite = starImage;
        }
    }

    private void ResetStarImages()
    {
        for (int i = 0; i < starCount; i++)
        {
            stars[i].sprite = oldStarImage;
        }
    }

    private int SetStarCount(WeaponValues weaponValues)
    {
        starCount = 1;
        var danger = weaponValues.dangerLevel;
        if (danger > 1) starCount = 1;
        if (danger > 45) starCount = 2;
        if (danger > 150) starCount = 3;
        if (danger > 300) starCount = 4;
        if (danger > 750) starCount = 5;

        return starCount;
    }
}