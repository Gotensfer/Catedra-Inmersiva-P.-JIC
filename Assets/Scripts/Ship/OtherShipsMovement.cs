using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OtherShipsMovement : MonoBehaviour
{
    [Header("Idle values")]
    [SerializeField] float periodIdle;
    [SerializeField] float deltaYIdle;
    [SerializeField] float upperLimitIdle;
    [SerializeField] float lowerLimitIdle;

    [Header("Movement values")]
    [SerializeField] float periodMovement;
    [SerializeField] float deltaYMovement;
    [SerializeField] float upperLimitMovement;
    [SerializeField] float lowerLimitMovement;
    [SerializeField] float timeToReachEnd;

    [SerializeField] Transform endPosition;

    Sequence movementSequence;
    Sequence idleSequence;

    private void Start()
    {
        lowerLimitIdle = transform.position.y;
        upperLimitIdle = lowerLimitIdle + deltaYIdle;

        lowerLimitMovement = lowerLimitIdle;        
        upperLimitMovement = lowerLimitMovement + deltaYMovement;

        StartShipIdle(); 
        //StartShipMovement();
        Invoke(nameof(StopShipIdle), 5f);

    }

    public void StartShipMovement()
    {
        movementSequence = DOTween.Sequence()
            .Append(transform.DOMoveY(upperLimitMovement, periodMovement / 2).SetEase(Ease.InOutQuad))
            .Append(transform.DOMoveY(lowerLimitMovement, periodMovement / 2).SetEase(Ease.InOutQuad));

        movementSequence.SetLoops(999, LoopType.Restart);

        transform.DOMoveX(endPosition.position.x, timeToReachEnd).SetEase(Ease.InOutSine);
        transform.DOMoveZ(endPosition.position.z, timeToReachEnd).SetEase(Ease.InOutSine);       
    }

    public void StartShipIdle()
    {
        StopShipMovement();

        idleSequence = DOTween.Sequence()
            .Append(transform.DOMoveY(upperLimitIdle, periodIdle / 2).SetEase(Ease.InOutQuad))
            .Append(transform.DOMoveY(lowerLimitIdle, periodIdle / 2).SetEase(Ease.InOutQuad));

        idleSequence.SetLoops(999, LoopType.Restart);
    }

    void StopShipIdle()
    {
        StartCoroutine(BeginMovement());
    }

    void StopShipMovement()
    {
        transform.DOTogglePause();
    }

    IEnumerator BeginMovement()
    {
        print("Coroutine started");
        yield return idleSequence.WaitForRewind();
        idleSequence.Complete();
        print("Completed coroutine");
        yield return null;
        StartShipMovement();
    }
}
