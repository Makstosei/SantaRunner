using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChild : MonoBehaviour
{
    void Awake()
    {
        var rand = Random.Range(0, this.gameObject.transform.childCount);
        this.gameObject.transform.GetChild(rand).gameObject.SetActive(true);
    }
}
