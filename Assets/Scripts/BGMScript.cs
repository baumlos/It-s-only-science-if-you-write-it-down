using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour
{
    private static BGMScript instance = null;

    public static BGMScript Instance
    {
        get { return instance; }
    }

    [SerializeField] private AudioClip buttonPressSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
            AudioSource.PlayClipAtPoint(buttonPressSound,new Vector3(0,0,-10));
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    
}
