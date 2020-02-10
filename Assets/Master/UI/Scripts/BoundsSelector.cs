using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsSelector : MonoBehaviour
{
    [SerializeField]
    Camera _camera;
    Bounds _bounds;
    Vector3 _initialPoint;
    Vector3 _currentPoint;
    List<GameObject> _selections;
    Texture2D _whiteTexture;

    public Color color;

    public Texture2D WhiteTexture
    {
        get
        {
            if (_whiteTexture == null)
            {
                _whiteTexture = new Texture2D(1, 1);
                _whiteTexture.SetPixel(0, 0, Color.white);
                _whiteTexture.Apply();
            }

            return _whiteTexture;
        }
    }

    public bool isSelecting = false;
    public int selectionCap = 10;

    public Bounds bounds { get { return _bounds; } }
    public Vector3 initialPoint { get { return _initialPoint; } }

    void Start()
    {

    }

    void Update()
    {
        //Update current point
        _currentPoint = Input.mousePosition;

        //When we click left click once...
        if (Input.GetMouseButtonDown(0))
        {
            //First set our selecting...
            isSelecting = true;
            //Get our starting mouse point;
            _initialPoint = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            //set bool
            isSelecting = false;
            //Clear bounds
            if (_bounds.size != null)
            {
                _bounds = new Bounds();
            }
        }

    }

    private void OnGUI()
    {
        if (isSelecting)
        {
            var rect = GetMouseRect();
            DrawMouseRect(rect, color);
        }
    }

    //If we're selecting, this will return the area of the bounds(box) to select.
    public void SetBounds()
    {
        var iP = _camera.ScreenToViewportPoint(_initialPoint);
        var cP = _camera.ScreenToViewportPoint(Input.mousePosition);
        var min = Vector3.Min(iP, cP);
        var max = Vector3.Max(iP, cP);
        min.z = _camera.nearClipPlane;
        max.z = _camera.farClipPlane;
        _bounds.SetMinMax(min, max);
    }

    //Create a rect based on mouse position.
    public Rect GetMouseRect()
    {
        _initialPoint.y = Screen.height - _initialPoint.y;
        _currentPoint.y = Screen.height - _currentPoint.y;
        var upperLeft = Vector3.Min(_initialPoint, _currentPoint);
        var bottomRight = Vector3.Max(_initialPoint, _currentPoint);
        return Rect.MinMaxRect(upperLeft.x, upperLeft.y, bottomRight.x, bottomRight.y);
    }


    public static Rect GetScreenRect(Vector3 screenPosition1, Vector3 screenPosition2)
    {
        // Move origin from bottom left to top left
        screenPosition1.y = Screen.height - screenPosition1.y;
        screenPosition2.y = Screen.height - screenPosition2.y;
        // Calculate corners
        var topLeft = Vector3.Min(screenPosition1, screenPosition2);
        var bottomRight = Vector3.Max(screenPosition1, screenPosition2);
        // Create Rect
        return Rect.MinMaxRect(topLeft.x, topLeft.y, bottomRight.x, bottomRight.y);
    }

    public void DrawMouseRect(Rect rect, Color color)
    {
        GUI.color = color;
        GUI.DrawTexture(rect, WhiteTexture);
        GUI.color = Color.white;
    }

}
