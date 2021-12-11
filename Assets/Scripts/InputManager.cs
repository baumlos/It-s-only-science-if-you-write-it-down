using Physics;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public bool EditState { get; set; } = true;

    [SerializeField] private Camera cam;
    [SerializeField] private Shooter shooter;
    [SerializeField] private SpiegelplatzierenScript sps;

    private void Update()
    {
        // not hovering over UI
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(1)) EditState = !EditState;
            if (EditState)
            {
                sps.updatePos(mousePos);
                if (Input.GetMouseButtonDown(0) )
                {
                    sps.spawnMirror();
                }
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