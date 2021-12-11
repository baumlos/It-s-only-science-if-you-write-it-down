using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 trans = Input.GetAxis("Vertical") * new Vector3(0, 1, 0) +
                        Input.GetAxis("Horizontal") * new Vector3(1, 0, 0);
        trans *= speed * Time.deltaTime;
        transform.Translate(trans,Space.World);
        //losecheck
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb.velocity.magnitude <= 0)
        {
            rb.Sleep();
            Debug.Log("You lose");
        }
        
    }
    
    
}
