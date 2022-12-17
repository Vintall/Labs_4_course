using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClassificationAlgorithm
{
    public abstract void ExecuteAlgorithm(ref List<ClusterPoint> points, ref List<ClusterInfo> clusters);
}
