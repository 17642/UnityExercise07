using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    StageManager stageManaeger;
    [SerializeField]
    GameObject player;

    float xCmp, yCmp;


    private void Awake()
    {
        float aspectRatio = Camera.main.aspect;
        xCmp = (float)stageManaeger.MapSizeX - aspectRatio*Camera.main.orthographicSize;
        yCmp = (float)(stageManaeger.MapSizeY - Camera.main.orthographicSize/aspectRatio);
    }

    private void Update()
    {
        Camera.main.transform.position = (new Vector3(Mathf.Clamp(player.transform.position.x, -xCmp, xCmp), Mathf.Clamp(player.transform.position.y, 1.2f-yCmp, yCmp-1.2f),-10));
    }
}
