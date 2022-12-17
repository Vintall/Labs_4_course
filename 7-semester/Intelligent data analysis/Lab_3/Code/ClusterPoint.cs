using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterPoint
{
    NVector position;
    int cluster_index;

    public int ClusterIndex
    {
        get => cluster_index;
        set => cluster_index = value;
    }
    public NVector Position
    {
        get => position;
    }

    public ClusterPoint(NVector point_position, int cluster_index)
    {
        this.position = point_position;
        this.cluster_index = cluster_index;
    }

}
