using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScript : MonoBehaviour
{
    [SerializeField] private GameObject postIt;
    [SerializeField] private Text winningText;

    private int dummy = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("You won");
        postIt.SetActive(true);
        winningText.text = $"It took you {dummy} refraction-units to complete the experiment.";
    }
}
