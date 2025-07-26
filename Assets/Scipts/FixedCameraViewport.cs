using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FixedCameraViewport : MonoBehaviour
{
    public Vector2 targetResolution = new Vector2(1080, 1920); // 9:16

    void Start()
    {
        float targetAspect = targetResolution.x / targetResolution.y;
        float windowAspect = (float)Screen.width / Screen.height;

        Camera cam = GetComponent<Camera>();

        if (windowAspect > targetAspect)
        {
            // Màn hình rộng hơn → dư chiều ngang → tạo viền đen 2 bên
            float scaleWidth = targetAspect / windowAspect;
            cam.rect = new Rect((1f - scaleWidth) / 2f, 0f, scaleWidth, 1f);
        }
        else if (windowAspect < targetAspect)
        {
            // Màn hình cao hơn → dư chiều dọc → tạo viền đen trên/dưới
            float scaleHeight = windowAspect / targetAspect;
            cam.rect = new Rect(0f, (1f - scaleHeight) / 2f, 1f, scaleHeight);
        }
        else
        {
            // Khớp đúng → full screen
            cam.rect = new Rect(0f, 0f, 1f, 1f);
        }
    }
}
