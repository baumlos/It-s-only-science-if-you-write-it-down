using System;
using Physics;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public bool EditState { get; set; }

    [SerializeField] private Camera cam;
    [SerializeField] private Shooter shooter;
    [SerializeField] private GameObject sceneEditor;

    private void Update()
    {
        // not hovering over UI
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            
            if (EditState)
            {
                // do edit stuff @Klaus
            }
            else
            {
                // do nothing on hover
                
                // do set new direction on mouse click
                if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
                {
                    shooter.Click(mousePos);
                }
            }
        }
    }
}