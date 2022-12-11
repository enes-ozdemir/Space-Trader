using System;
using DG.Tweening;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    public bool isSellButton;

    public static Action<bool> onButtonPushed;

    private void Clicked() => onButtonPushed.Invoke(isSellButton);

    public float pressPower;
    public float pressDuration;
    public int vibration;
    public float elasticly;

    private void OnMouseDown()
    {
        Debug.Log(isSellButton ? "Item sold" : "Item not sold");

        Clicked();
        ClickedEffect();
    }

    private void ClickedEffect()
    {
        transform.DOPunchScale(Vector3.down * pressPower, pressDuration, vibration, elasticly);
    }
}