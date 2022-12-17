using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMeansClassification : ClassificationAlgorithm
{
    public override void ExecuteAlgorithm(ref List<ClusterPoint> points, ref List<ClusterInfo> clusters)
    {
        if (clusters == null)
            return;

        if (points == null)
            return;

        if(clusters.Count == 0) 
            return;

        foreach (ClusterPoint point in points)
        {
            float[] point_pos = point.Position.Vector;
            int nearest_cluster_index = 0;

            float axis_sum = 0;
            for (int pos_index = 0; pos_index < clusters[0].Position.Vector.Length; pos_index++)
                axis_sum += Mathf.Pow(clusters[0].Position.Vector[pos_index] - point_pos[pos_index], 2);

            float len = Mathf.Sqrt(axis_sum);

            float distance_to_nearest_cluster = len;

            foreach (ClusterInfo cluster in clusters)
            {
                float[] cluster_pos = cluster.Position.Vector;
                axis_sum = 0;
                for (int pos_index = 0; pos_index < cluster_pos.Length; pos_index++)
                    axis_sum += Mathf.Pow(cluster_pos[pos_index] - point_pos[pos_index], 2);

                len = Mathf.Sqrt(axis_sum);

                if(len < distance_to_nearest_cluster)
                {
                    distance_to_nearest_cluster = len;
                    nearest_cluster_index = cluster.ClusterIndex;
                }
            }

            point.ClusterIndex = clusters[nearest_cluster_index].ClusterIndex;
        }

        Dictionary<int, (float[], int)> new_pos = new();
        int vec_size = clusters[0].Position.Vector.Length;

        foreach(ClusterPoint point in points)
        {
            if (!new_pos.ContainsKey(point.ClusterIndex))
                new_pos.Add(point.ClusterIndex, (point.Position.Vector, 1));
            else
            {
                float[] new_new_pos = new float[vec_size];
                for (int i = 0; i < vec_size; i++)
                {
                    new_new_pos[i] += point.Position.Vector[i] + new_pos[point.ClusterIndex].Item1[i];
                }
                new_pos[point.ClusterIndex] = (new_new_pos, new_pos[point.ClusterIndex].Item2 + 1);
            }
                
        }
        foreach (KeyValuePair<int, (float[], int)> key_value_pair in new_pos)
        {
            for (int i = 0; i < vec_size; i++)
                key_value_pair.Value.Item1[i] /= key_value_pair.Value.Item2;

            clusters[key_value_pair.Key].Position = new NVector(key_value_pair.Value.Item1);
        }
    }

}
