using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] AudioSource coinFX;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        coinFX.Play();
        MasterInfo.cointCount += 1;
        this.gameObject.SetActive(false);
    }
}
