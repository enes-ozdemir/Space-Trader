using System;
using DG.Tweening;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    public bool isSellButton;
    public bool isInfoButton;

    public static Action<bool> onButtonPushed;
    public static Action onInfoButtonPushed;

    public static bool isGameOver;

    private void Clicked()
    {
        if(isGameOver) return;
        if (!isInfoButton) onButtonPushed.Invoke(isSellButton);
        else onInfoButtonPushed.Invoke();
    }

    public float pressPower;
    public float pressDuration;
    public int vibration;
    public float elasticly;

    private void OnMouseDown()
    {
        if(isGameOver) return;
        Debug.Log(isSellButton ? "Item sold" : "Item not sold");

        Clicked();
        ClickedEffect();
    }

    private void ClickedEffect()
    {
        transform.DOPunchScale(Vector3.down * pressPower, pressDuration, vibration, elasticly);
    }
}