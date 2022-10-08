using UnityEngine;

public class FacingCameraObject : MonoBehaviour
{
    private Camera _camera;

    // Start is called before the first frame update
    void Awake()
    {
        this._camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.eulerAngles = this._camera.transform.eulerAngles;
    }
}
