using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject trailRendererPreset;
    [SerializeField, Range(1, 100)] int renderersCount = 1;
    [SerializeField, Range(1, 100)] float delta;

    private void Start()
    {
        for (int i = 0; i < renderersCount; ++i)
        {
            float rndX = Random.Range(-delta, delta);
            float rndY = Random.Range(-delta, delta);
            float rndZ = Random.Range(-delta, delta);

            Instantiate(trailRendererPreset, new Vector3(rndX, rndY, rndZ), Quaternion.identity);
        }
    }
}
