using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GiftListMaterialUpdater : MonoBehaviour
{
    public List<Transform> gifts = new List<Transform>();

    public Material activeMaterial;
    public int activeGiftNumber;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            gifts.Add(this.transform.GetChild(i));
        }

        gifts = gifts.OrderBy(x => Vector3.Distance(Vector3.zero, x.transform.position)).ToList<Transform>();
        UpdateMaterial();
    }

    public void UpdateActiveGiftNumber()
    {
        activeGiftNumber++;
       activeGiftNumber= Mathf.Clamp(activeGiftNumber, 0, gifts.Count - 1);
    }

    public void UpdateMaterial()
    {
        if (gifts.Count > 0)
        {
            if (gifts[activeGiftNumber] != null)
            {
                gifts[activeGiftNumber].GetChild(0).GetComponent<MeshRenderer>().material = activeMaterial;
            }
        }
    }
}
