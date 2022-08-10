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

    [SerializeField] Movement movement;
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
    }

    public void StartShipMovement()
    {
        movementSequence = DOTween.Sequence()
            .Append(transform.DOMoveY(upperLimitMovement, periodMovement / 2).SetEase(Ease.InOutQuad))
            .Append(transform.DOMoveY(lowerLimitMovement, periodMovement / 2).SetEase(Ease.InOutQuad));

        movementSequence.SetLoops(999, LoopType.Restart);

        transform.DOMoveX(endPosition.position.x, timeToReachEnd).SetEase(Ease.InOutSine);
        transform.DOMoveZ(endPosition.position.z, timeToReachEnd).SetEase(Ease.InOutSine).OnComplete(() => { StartCoroutine(BeginIdleWaveMovement()); });       
    }

    public void StartShipIdle()
    {
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
        StartCoroutine(BeginIdleWaveMovement());        
    }


    IEnumerator BeginIdleWaveMovement()
    {
        print("Called iddle coroutine");
        yield return movementSequence.WaitForElapsedLoops(1);

        movementSequence.Complete();
        movementSequence.Kill();
        yield return null;

        StartShipIdle();
        print("Finish coroutine");
    }

    public IEnumerator BeginMovement()
    {
        yield return idleSequence.WaitForElapsedLoops(1); // si, despues de 3h figuré que esta era la forma para solucionar el problema del Stutter sin necesidad que coordinar otro Tweener durante previo a la nueva secuencia.
        idleSequence.Complete(); // Completar la secuencia para evitar los "residuos" del tweener entrando en conflicto con el siguiente
        idleSequence.Kill();

        yield return null; // Esperar un frame, solo por sanidad personal.
        StartShipMovement();
        movement.Move();
        movement.CanMove = true;
    }

    private void OnDisable()
    {
        idleSequence.Kill();
        movementSequence.Kill();
    }
}
