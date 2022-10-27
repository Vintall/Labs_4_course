using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstructionGenerator : MonoBehaviour
{
    
    List<Transform> active_bricks = new List<Transform>();

    public void ClearObstructions()
    {
        foreach(Transform t in active_bricks)
        {
            Destroy(t.gameObject);
        }

        active_bricks.Clear();
    }
    private void Start()
    {
        StartCoroutine(SpawnBrick());
    }
    private void Update()
    {
        List<Transform> copy = new List<Transform>(active_bricks);

        foreach (Transform t in copy)
        {
            t.position += new Vector3(0, -GameController.Instance.RunwaySpeed * Time.deltaTime, 0);

            if(t.position.y <= -15)
            {
                Transform buff = t;

                active_bricks.Remove(t);

                Destroy(buff.gameObject);
            }
        }
    }

    IEnumerator SpawnBrick()
    {
        yield return new WaitForSeconds(GameController.Instance.GenerationDelay);

        active_bricks.Add(Instantiate(GameController.Instance.BrickAsset, GameController.Instance.BricksHolder).transform);
        active_bricks[active_bricks.Count - 1].position = new Vector3(Random.Range(-1,2)*1.5f,
            15, active_bricks[active_bricks.Count - 1].position.z);

        StartCoroutine(SpawnBrick());
    }
}
