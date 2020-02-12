using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Terrain map;
    public float panRate = 0.25f;
    public Vector3 margin = new Vector3(10f, 0, 10f);
    [SerializeField]
    Vector3 minBoundary = new Vector3(-35.7f, 0, -35.7f);
    [SerializeField]
    Vector3 maxBoundary = new Vector3(35.7f, 0, 35.7f);
    Vector3 cameraPosition;

    private void Start()
    {
        if(map != null)
        {
            SetBoundary(map, minBoundary, maxBoundary);
        }
    }

    void Update()
    {
        cameraPosition = transform.position + new Vector3(ScreenEdgeHorizontal() * panRate, 0, ScreenEdgeVertical() * panRate);
        cameraPosition.x = Mathf.Clamp(cameraPosition.x, minBoundary.x + margin.x, maxBoundary.x - margin.x);
        cameraPosition.z = Mathf.Clamp(cameraPosition.z, minBoundary.z + margin.z, maxBoundary.z - margin.z);
        transform.position = cameraPosition;
    }

    float ScreenEdgeHorizontal()
    {
        if (Input.mousePosition.x <= 0)
            return -1f;
        else if (Input.mousePosition.x >= Screen.width)
            return 1f;
        else
            return 0f;
    }

    float ScreenEdgeVertical()
    {
        if (Input.mousePosition.y <= 0)
            return -1f;
        else if (Input.mousePosition.y >= Screen.height)
            return 1f;
        else
            return 0f;
    }

    void SetBoundary(Terrain t, Vector3 min, Vector3 max)
    {
        Vector3 boundary = new Vector3((float)(t.terrainData.size.x / 2f), 0, (float)(t.terrainData.size.z / 2f));
        minBoundary = boundary * -1f;
        maxBoundary = boundary;
    }


}
