using UnityEngine;
using UnityEngine.UI;

public class ToggleCanvasVisibility : MonoBehaviour
{
    public Canvas canvas1;
    public Canvas canvas2;

    public void ToggleCanvases()
    {
        if (canvas1 != null && canvas2 != null)
        {
            bool isCanvas1Active = canvas1.gameObject.activeSelf;
            canvas1.gameObject.SetActive(!isCanvas1Active);
            canvas2.gameObject.SetActive(isCanvas1Active);
        }
    }
}
