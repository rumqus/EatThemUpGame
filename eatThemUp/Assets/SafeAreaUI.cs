using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SafeAreaUI : MonoBehaviour
{
    [SerializeField] private Canvas mainUI; // main canvas with UI
    RectTransform panelSafeArea;
    Rect currentArea;
    ScreenOrientation currentOrientation = ScreenOrientation.AutoRotation;
    

    // Start is called before the first frame update
    void Start()
    {
        panelSafeArea = GetComponent<RectTransform>();
        currentOrientation = Screen.orientation;
        currentArea = Screen.safeArea;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentOrientation != Screen.orientation || currentArea != Screen.safeArea)
        {
            ApplySafeArea();
        }
    }

    private void ApplySafeArea() 
    {
        if (panelSafeArea == null)
        {
            return;
        }
        Rect safeArea = Screen.safeArea;
        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position - safeArea.size;

        anchorMin.x /= mainUI.pixelRect.width;
        anchorMin.y /= mainUI.pixelRect.height;

        anchorMax.x /= mainUI.pixelRect.width;
        anchorMax.y /= mainUI.pixelRect.height;
        panelSafeArea.anchorMin = anchorMin;
        panelSafeArea.anchorMax = anchorMax;

        currentOrientation = Screen.orientation;
        currentArea = Screen.safeArea;
    }

}
