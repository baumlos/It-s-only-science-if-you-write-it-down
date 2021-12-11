using Physics;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public bool EditState { get; set; } = true;
    public  bool DeleteState;

    [SerializeField] private Camera cam;
    [SerializeField] private Shooter shooter;
    [SerializeField] private SpiegelmanagerScript sms;
    [SerializeField] private SpiegelplatzierenScript sps;

    private void Update()
    {
        // not hovering over UI
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(1)) {
                EditState = !EditState;
                if(!EditState) sps.gameObject.SetActive(false);
            }
            if (EditState)
            {
                if (Input.GetKeyDown("space"))
                {
                    DeleteState = !DeleteState;
                    sps.gameObject.SetActive(!DeleteState);
                }
                if(!DeleteState){

                sps.updatePos(mousePos);
                    if (Input.GetMouseButtonDown(0))
                    {
                        var mirror = sps.spawnMirror();
                        if(mirror==null) Debug.Log("kacka");
                        else
                        {
                            sms.createMirror(mirror);
                        }
                        //sms.createMirror(sps.spawnMirror());
                    }
                }
            }
            else
            {
                // do nothing on hover
                
                // do set new direction on mouse click
                if (Input.GetMouseButton(0) )
                {
                    shooter.Click(mousePos);
                }
            }
        }
        else
        {
            sps.gameObject.SetActive(false);
        }
    }
}