using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployGiftParticleActivation : MonoBehaviour
{
    [SerializeField] private GameObject _deployGift;
    public void DeployGift()
    {
        _deployGift.SetActive(true);
    }
}
