using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GiftRotate : MonoBehaviour
{
    void Start()
    {
        transform.DOLocalRotate(new Vector3(0, 360, 0), 3, RotateMode.FastBeyond360).SetRelative(true).SetLoops(-1,LoopType.Incremental).SetEase(Ease.Linear);
    }

    
}
