using UnityEngine;
using UnityEngine.UIElements;

public class ResolutionManager : MonoBehaviour
{
    public int width = 1280;
    public int height = 720;
    public bool fullscreen = false;
    void Start()
    {
        Screen.SetResolution(width,height,fullscreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
