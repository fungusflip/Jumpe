using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOULDERSPAWN : MonoBehaviour
{
    [SerializeField] private GameObject BOulder;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BOulder.SetActive(true);
        }
    }
}
