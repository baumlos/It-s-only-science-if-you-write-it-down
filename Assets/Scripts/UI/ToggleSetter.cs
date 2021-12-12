using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ToggleSetter : MonoBehaviour
    {
        [Header("Internal References")]
        [SerializeField] private Toggle editToggle;
        [SerializeField] private Toggle deleteToggle;
        [SerializeField] private Toggle trajectoryToggle;

        public void SetToggleCorrectly(bool edit, bool delete)
        {
            if (edit && delete)
            {
                editToggle.SetIsOnWithoutNotify(false);
                deleteToggle.SetIsOnWithoutNotify(true);
                trajectoryToggle.SetIsOnWithoutNotify(false);
            }
            else if(edit)
            {
                editToggle.SetIsOnWithoutNotify(true);
                deleteToggle.SetIsOnWithoutNotify(false);
                trajectoryToggle.SetIsOnWithoutNotify(false);
            }
            else if(!delete)
            {
                editToggle.SetIsOnWithoutNotify(false);
                deleteToggle.SetIsOnWithoutNotify(false);
                trajectoryToggle.SetIsOnWithoutNotify(true);
            }
        }
        
    }
}