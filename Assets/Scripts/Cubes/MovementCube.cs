using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MovementCube : MonoBehaviour
{

    public float xPos;
    public float duration;

    private Tween tween;
    public void Move()
    {
        tween=transform.DOLocalMoveX(xPos,duration);
    }

    public void KillTween()
    {
        tween.Kill();
    }
}
