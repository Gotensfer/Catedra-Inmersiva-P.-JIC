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

        //StartShipIdle(); 
        StartShipMovement();
        Invoke(nameof(StartShipIdle), 3f);
    }


    public void StartShipMovement()
    {
        StopShipIdle();

        movementSequence = DOTween.Sequence()
            .Append(transform.DOMoveY(upperLimitMovement, periodMovement / 2).SetEase(Ease.InOutQuad))
            .Append(transform.DOMoveY(lowerLimitMovement, periodMovement / 2).SetEase(Ease.InOutQuad));

        movementSequence.SetLoops(-1, LoopType.Restart);

        transform.DOMoveX(endPosition.position.x, timeToReachEnd).SetEase(Ease.InOutSine);
        transform.DOMoveZ(endPosition.position.z, timeToReachEnd).SetEase(Ease.InOutSine);       
    }

    public void StartShipIdle()
    {
        StopShipMovement();

        idleSequence = DOTween.Sequence()
            .Append(transform.DOMoveY(upperLimitIdle, periodIdle / 2).SetEase(Ease.InOutQuad))
            .Append(transform.DOMoveY(lowerLimitIdle, periodIdle / 2).SetEase(Ease.InOutQuad));

        idleSequence.SetLoops(-1, LoopType.Restart);
    }

    void StopShipIdle()
    {
        idleSequence.TogglePause();
    }

    void StopShipMovement()
    {
        transform.DOTogglePause();
    }
}
