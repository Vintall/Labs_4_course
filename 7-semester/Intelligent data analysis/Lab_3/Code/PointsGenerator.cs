using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;


[ExecuteInEditMode]
public class PointsGenerator : MonoBehaviour
{
    string file_path;
    [SerializeField] string file_name; 
    [SerializeField] int points;
    [SerializeField] int clusters;

    [SerializeField] List<DimentionWithRange> dimentions;


    [Serializable]
    public struct DimentionWithRange
    {
        public Vector2 range;
    }
    public void OpenFileExplorer()
    {
        file_path = EditorUtility.OpenFolderPanel("Points File", Application.dataPath, "PLF");
    }
    public void Generate()
    {
        if (string.IsNullOrEmpty(file_path) || string.IsNullOrEmpty(file_name))
        {
            Debug.Log($"ERROR!  FilePath: \"{file_path}\"   FileName: \"{file_name}\"");
            return;
        }
        if(clusters > points)
        {
            Debug.Log("Points count cannot be less than clusters count \n" +
                $"Clusters Count: {clusters}  Points Count: {points}");
            return;
        }


        string full_path = $"{file_path}/{file_name}";
        if (!Directory.Exists(full_path))
            Directory.CreateDirectory(full_path);

        string points_path = $"{full_path}/{file_name}.PLF";
        string clusters_path = $"{full_path}/{file_name}.CLF";

        if (!File.Exists(points_path))
            File.Create(points_path);

        if (!File.Exists(clusters_path))
            File.Create(clusters_path);

        string points_content = "";
        string clusters_content = "";

        List<float[]> clusters_pos = new List<float[]>();
        {
            for (int i = 0; i < points; i++)
            {
                if (i < clusters)
                {
                    clusters_pos.Add(new float[dimentions.Count]);
                }

                points_content += dimentions.Count.ToString() + '|';
                for (int j = 0; j < dimentions.Count; j++)
                {
                    float range_value = UnityEngine.Random.Range(dimentions[j].range.x, dimentions[j].range.y);
                    if (i < clusters)
                    {
                        clusters_pos[clusters_pos.Count - 1][j] = range_value;
                    }


                    points_content += range_value;

                    if (j != dimentions.Count - 1)
                        points_content += '|';
                }
                points_content += "\n";
            }
            File.WriteAllText(points_path, points_content);
        } // Points
        {
            for (int i = 0; i < clusters; i++)
            {
                clusters_content += dimentions.Count.ToString() + '|';
                for (int j = 0; j < dimentions.Count; j++)
                {
                    clusters_content += clusters_pos[i][j];
                    clusters_content += '|';
                }
                clusters_content += (i + 1).ToString();
                clusters_content += "\n";
            }
            File.WriteAllText(clusters_path, clusters_content);
        } // Clusters
    }
}