using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    [SerializeField] TrailRenderer trailRenderer;
    void Start()
    {
        AddNewPoint(transform.position);
        StartCoroutine(AddNewPointCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AddNewPointCoroutine()
    {
        yield return new WaitForSeconds(0.01f);

        AddNewPoint(trailRenderer.GetPosition(trailRenderer.positionCount - 1));

        StartCoroutine(AddNewPointCoroutine());
    }
    void AddNewPoint(Vector3 point)
    {
        Vector3 prevPosition = point;
        Vector3 delta = MyFunction.XYZ(prevPosition).normalized * 5f;

        Vector3 newPosition = prevPosition + delta;

        Debug.Log(newPosition);

        trailRenderer.AddPosition(newPosition);
        transform.position = newPosition;
    }
}
