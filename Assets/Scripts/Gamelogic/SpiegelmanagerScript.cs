using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpiegelmanagerScript : MonoBehaviour
{
    private List<GameObject> mirrors = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createMirror(GameObject mirror)
    {
        if(mirror==null) Debug.Log("Kacka2");
        else  mirrors.Add(mirror);
        Debug.Log("List size: "+mirrors.Count);
    }


    public void resetList()
    {
        foreach (var mirror in mirrors)
        {
            Destroy(mirror);
        }
    }

    public int count()
    {
        return mirrors.Count(m => m != null);
    }
}
