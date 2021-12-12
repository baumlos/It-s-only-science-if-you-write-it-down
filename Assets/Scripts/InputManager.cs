using Physics;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    private bool editState = true;

    public bool EditState
    {
        get => editState;
        set
        {
            editState = value;
            sps.gameObject.SetActive(value && !DeleteState);
        }
    }

    public bool DeleteState { get; set; }

    [SerializeField] private Camera cam;
    [SerializeField] private Shooter shooter;
    [SerializeField] private SpiegelmanagerScript sms;
    [SerializeField] private SpiegelplatzierenScript sps;
    [SerializeField] private ToggleSetter togglesetter;

    private void Update()
    {
        // not hovering over UI
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            
            if(sps.gameObject.activeSelf==false)
                sps.gameObject.SetActive(EditState && !DeleteState);

            // if (Input.GetMouseButtonDown(1))
            // {
            //     EditState = !EditState;
            //     togglesetter.SetToggleCorrectly(EditState,DeleteState);
            // }

            if (EditState)
            {
                // if (Input.GetKeyDown("space"))
                // {
                //     DeleteState = !DeleteState;
                //     togglesetter.SetToggleCorrectly(EditState,DeleteState);
                //     sps.gameObject.SetActive(!DeleteState);
                // }

                if (!DeleteState)
                {
                    sps.updatePos(mousePos);
                    if (Input.GetMouseButtonDown(0))
                    {
                        var mirror = sps.spawnMirror();
                        if (mirror == null) Debug.Log("kacka");
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
                if (Input.GetMouseButton(0))
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

    public void CreateToggle(bool isEnabled)
    {
        if (isEnabled)
        {
            EditState = true;
            DeleteState = false;
        }
        else
        {
            EditState = false;
        }
    }

    public void DeleteToggle(bool isEnabled)
    {
        if (isEnabled)
        {
            EditState = true;
            DeleteState = true;
        }
        else
        {
            EditState = false;
            DeleteState = false;
        }
    }

    public void TrajectoryToggle(bool isEnabled)
    {
        if (isEnabled)
        {
            EditState = false;
            DeleteState = false;
        }
        else
        {
            EditState = true;
        }
    }
}