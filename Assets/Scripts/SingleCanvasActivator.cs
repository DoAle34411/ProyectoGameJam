using UnityEngine;

public class SingleCanvasActivator : MonoBehaviour
{
    public Canvas activeCanvas;
    public Canvas inactiveCanvas;

    void Start()
    {
        SetActiveCanvas(activeCanvas);
    }

    public void SetActiveCanvas(Canvas canvas)
    {
        if (canvas != null)
        {
            activeCanvas = canvas;
            activeCanvas.gameObject.SetActive(true);
            inactiveCanvas.gameObject.SetActive(false);
        }
    }
}
