using UnityEngine;

public class PlayerCam : MonoBehaviour
{


    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }


    void Update()
    {
        //get mouse input
        float mouseX = input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clmap(xRotation, -90f, 90f);

        //rotate cam and orietation
        transfrom.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orietation.roatation = Quaternion.Euler(0, yRotation, 0);
    }
}
