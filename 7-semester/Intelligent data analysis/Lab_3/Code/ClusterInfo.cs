using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterInfo
{
    string cluster_name;
    NVector position;
    int cluster_index;
    public Color color;


    public NVector Position
    {
        get => position;
        set => position = value;
    }
    public string ClusterName => cluster_name;
    public int ClusterIndex => cluster_index;

    public ClusterInfo(NVector position, string name, int cluster_index, Color color)
    {
        this.position = position;
        this.cluster_name = name;
        this.cluster_index = cluster_index;
        this.color = color;
    }
}
