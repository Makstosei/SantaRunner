using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GiftMaterialTrigger : MonoBehaviour
{
    private bool _isCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (!_isCollected)
        {
            if (other.CompareTag("Deer") || other.CompareTag("Player"))
            {
                _isCollected = true;
                var referance = this.transform.parent.transform.parent.GetComponent<GiftListMaterialUpdater>();
                referance.UpdateActiveGiftNumber();
                referance.UpdateMaterial();
            }
        }
    }
}
