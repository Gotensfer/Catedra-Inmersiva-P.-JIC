using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{


    bool canMove = false;
    public bool CanMove { get => canMove; set => canMove = value;}

    bool alreadyMoved = false;
    public bool AlreadyMoved { get => alreadyMoved; set => alreadyMoved = value; }

    bool hasStoped = false;
    public bool HasStoped { get => hasStoped; set => hasStoped = value; }

    [SerializeField] Transform endPosition;
    [SerializeField] float timeToReachEnd;
    [SerializeField] Outline colonOutline;

    public void Move()
    {
        if (!alreadyMoved)
        {
            transform.DOMove(endPosition.position, timeToReachEnd).SetEase(Ease.InOutSine).OnComplete(AllowColon);
            alreadyMoved = true;
        }
    }

    void AllowColon()
    {
        hasStoped = true;
        colonOutline.OutlineWidth = 4;
    }

    private void OnDisable()
    {
        DOTween.Clear();
    }
}
