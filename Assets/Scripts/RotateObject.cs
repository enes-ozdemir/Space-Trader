using DG.Tweening;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationDuration = 24f;
    public float rotateAroundItselfDuration = 24f;
    public RotateMode rotateMode;
    public Transform rotateAround;

    private void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), rotateAroundItselfDuration, rotateMode).SetLoops(-1)
            .SetEase(Ease.Linear).SetRelative(true);
    }

    private void Update()
    {
        transform.RotateAround(rotateAround.position, new Vector3(0, 1, 0), rotationDuration * Time.deltaTime);
    }
}