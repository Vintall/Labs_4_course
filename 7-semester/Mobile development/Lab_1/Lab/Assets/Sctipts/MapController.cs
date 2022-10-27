using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    static MapController instance;
    public static MapController Instance => instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    [SerializeField] Transform tile1;
    [SerializeField] Transform tile2;


    private void Update()
    {
        tile1.position += new Vector3(0, -GameController.Instance.RunwaySpeed * Time.deltaTime, 0);
        tile2.position += new Vector3(0, -GameController.Instance.RunwaySpeed * Time.deltaTime, 0);


        if (tile1.position.y <= -10.5)
            tile1.position = new Vector3(0, tile2.position.y + 10.5f, 0);

        if (tile2.position.y <= -10.5)
            tile2.position = new Vector3(0, tile1.position.y + 10.5f, 0);
    }
}
