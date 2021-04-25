using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Application : MonoBehaviour
{
    public SearchBar searchbar;
    //Application General Settings
    public GameObject application;
    public bool buyuk = true;
    private Vector3 miniScale;
    public Vector3 miniPosition;
    private Vector3 maxScale;
    private Vector3 maxPosition;

    //Drag&Drop Settings
    private Vector3 mOffset;
    private float mZCoord;
    public Camera camera;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Start()
    {
        miniScale = new Vector3(0.50f, 0.50f, 1);
        miniPosition = new Vector3(application.transform.position.x, application.transform.position.y, application.transform.position.z);
        maxScale = new Vector3(1, 1, 1);
        maxPosition = new Vector3(application.transform.position.x, application.transform.position.y, application.transform.position.z);
    }


    public void alta_alma()
    {
        application.SetActive(false);
    }

    public void reSize()
    {
        if (buyuk)
        {
            application.transform.localScale = miniScale;
            application.transform.position = miniPosition;
            buyuk = false;
        }
        else
        {
            application.transform.localScale = maxScale;
            application.transform.position = maxPosition;
            buyuk = true;
        }
    }

    void OnMouseDown()
    {
        this.gameObject.transform.SetAsLastSibling();
        
        if (!buyuk)
        {
            mZCoord = camera.WorldToScreenPoint(gameObject.transform.position).z;

            // Store offset = gameobject world pos - mouse world pos
            mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        }
    }

    private Vector3 GetMouseAsWorldPoint()

    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return camera.ScreenToWorldPoint(mousePoint);
    }



    void OnMouseDrag()

    {
        if (!buyuk)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y,minY,maxY), transform.position.z);

            miniPosition = transform.position;
        }
    }
}
