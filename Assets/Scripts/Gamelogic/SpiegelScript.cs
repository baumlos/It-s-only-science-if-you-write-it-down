using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiegelScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private InputManager im;
    private static readonly int Color1 = Shader.PropertyToID("_color");

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        im = FindObjectOfType<InputManager>();
        Physics2D.queriesHitTriggers = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

   

    public void OnMouseOver()
    {
        if (!im.DeleteState) return;
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }

    }

    private void OnMouseEnter()
    {
        if (im.DeleteState)
        {
            spriteRenderer.color = Color.red;
        }
    }

    private void OnMouseExit()
    {if (im.DeleteState)
        {
            spriteRenderer.color = Color.white;
        }
    }
}
