using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScript : MonoBehaviour
{
    [SerializeField] private GameObject postIt;
    [SerializeField] private Text winningText;
    [SerializeField] private SpiegelmanagerScript sms;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.tag.Equals("Projectile")) return;
        Debug.Log("You won");
        postIt.SetActive(true);
        winningText.text = $"It took you {sms.count()} refraction-units to complete the experiment.";
    }
}
