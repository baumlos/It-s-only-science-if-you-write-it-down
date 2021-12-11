using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpiegelplatzierenScript : MonoBehaviour
{
    [SerializeField] private bool placeable = true;
    [SerializeField] private GameObject mirrorspawn;
    private Material material;
    private Collider2D _collider;
    private int collcounter;
    private double[] buffer;
    private static readonly int Color1 = Shader.PropertyToID("_Color");
    private List<GameObject> mirrorlist;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        _collider = GetComponent<Collider2D>();
        collcounter = 0;
        buffer = new double[10];
        for (int i = 0; i < 10 ; i++)
        {
            buffer[i] = 0.5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            transform.Rotate(0,0,22.5f,Space.World);
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            transform.Rotate(0,0,-22.5f,Space.World);
        }

        
    }

    private void FixedUpdate()
    {
        double val;
        if (_collider.IsTouchingLayers(256)) val = 0;
        else val = 1;
        buffer[collcounter] = val;
        collcounter++;
        collcounter %= 10;
        if (buffer.Average() >= 0.5) placeable = true;
        else placeable = false;
    }


    public void updatePos(Vector3 mousePos)
    {
        Vector3 newPos = new Vector3(mousePos.x, mousePos.y, 0);
        transform.position = newPos;
        checkColor();
    }

    private void checkColor()
    {
        if(placeable ) material.SetColor(Color1,Color.green);
        if(!placeable) material.SetColor(Color1,Color.red);
    }

    public bool spawnMirror()
    {
        if (buffer.Average() > 0.9)
        {
            GameObject spawn;
            spawn = Instantiate(mirrorspawn);
            var transform1 = transform;
            spawn.transform.position = transform1.position;
            spawn.transform.rotation = transform1.rotation;

            return true;
        }
        else
        {
            return false;
        }
    }

    public void resetLevel()
    {
        foreach (var variable in mirrorlist)
        {
            Destroy(variable);
        }
    }
}
