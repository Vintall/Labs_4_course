using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameController;

public class GameController : MonoBehaviour
{
    static GameController instance;
    public static GameController Instance => instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    List<ClusterInfo> clusters = null;
    List<ClusterPoint> points = null;

    [SerializeField] ComputeShader main_compute_shader;
    [SerializeField] Material main_material;
    [SerializeField] RenderTexture main_render_texture;


    public const int VectorSize = 3;
    public void ImportPointsFromFile(string[] file_lines)
    {
        points = new List<ClusterPoint>();

        string current_point_cluster = null;

        bool first_iteration = true;

        foreach (string line in file_lines)
        {
            if (string.IsNullOrEmpty(line))
                continue;

            string[] line_parts = line.Split('|');

            int vector_size = int.Parse(line_parts[0]);

            if (first_iteration)
            {
                UIController.Instance.InitializeVectorField(vector_size);

                List<string> axis_names = new List<string>();
                for (int i = 0; i < vector_size; i++)
                    axis_names.Add($"Axis: \"{i + 1}\"");

                UIController.Instance.InitializeGraphicsAxis(axis_names);

                first_iteration = false;
            }

            List<float> vector = new List<float>(vector_size);

            for (int i = 1; i <= vector_size; i++)
            {
                string float_base = line_parts[i];
                string float_correct = "";

                for (int j = 0; j < float_base.Length; j++)
                    if (float_base[j] == '.')
                        float_correct += ',';
                    else
                        float_correct += float_base[j];

                vector.Add(float.Parse(float_correct));
            }
            points.Add(new ClusterPoint(new NVector(vector.ToArray()), -1));
        }
    }
    public void ImportClustersFromFile(string[] file_lines)
    {
        clusters = new List<ClusterInfo>();
        bool first_iteration = true;
        int cluster_index = 0;
        try
        {
            foreach (string line in file_lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] line_parts = line.Split('|');

                int vector_len = int.Parse(line_parts[0]);

                if (first_iteration)
                {
                    UIController.Instance.InitializeVectorField(vector_len);

                    List<string> axis_names = new List<string>();
                    for (int i = 0; i < vector_len; i++)
                        axis_names.Add($"Axis: \"{i + 1}\"");

                    UIController.Instance.InitializeGraphicsAxis(axis_names);

                    first_iteration = false;
                }

                List<float> vec = new List<float>();

                for (int i = 1; i <= vector_len; i++)
                {
                    string float_base = line_parts[i];
                    string float_correct = "";

                    for (int j = 0; j < float_base.Length; j++)
                        if (float_base[j] == '.')
                            float_correct += ',';
                        else
                            float_correct += float_base[j];

                    vec.Add(float.Parse(float_correct));
                }

                string cluster_name = line_parts[vector_len + 1];
                Color new_color = new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), 1);
                clusters.Add(new ClusterInfo(new NVector(vec.ToArray()), cluster_name, cluster_index++, new_color));
            }
        }
        catch { }
    }

    ClassificationAlgorithm current_algorithm = null;
    public void ExecuteClassificationAlgorithm(string algorithm_name)
    {
        switch (algorithm_name)
        {
            case "K-Means":
                current_algorithm = new KMeansClassification();
                break;
            case "K-Nearest":
                current_algorithm = new KNearestClassification();
                break;
        }
    }
    public struct MyPoint
    {
        public float position_x;
        public float position_y;

        public int cluster_index;
    }
    public struct MyCluster
    {
        public float position_x;
        public float position_y;

        public int cluster_index;

        public float color_r;
        public float color_g;
        public float color_b;
        public float color_a;


    }
    const int MyPointSize = 4 + 4 + 4;
    const int MyClusterSize = 4 + 4 + 4 + 4 + 4 + 4 + 4;

    int x_axis_index = 0;
    int y_axis_index = 0;

    public void ChangeAxis(int x_axis, int y_axis)
    {
        x_axis_index = x_axis;
        y_axis_index = y_axis;

        UpdateShader();
    }
    void SetPoints(out ComputeBuffer points_buffer)
    {
        List<MyPoint> shader_points = new List<MyPoint>();
        foreach (ClusterPoint point in points)
        {
            MyPoint new_point = new MyPoint();

            new_point.position_x = point.Position.Vector[x_axis_index];
            new_point.position_y = point.Position.Vector[y_axis_index];
            new_point.cluster_index = point.ClusterIndex;

            shader_points.Add(new_point);
        }
        points_buffer = new ComputeBuffer(shader_points.Count, shader_points.Count * MyPointSize);
        //Debug.Log($"Points Count: {shader_points.Count}");
        points_buffer.SetData(shader_points.ToArray());
        main_compute_shader.SetBuffer(0, "points", points_buffer);
        main_compute_shader.SetInt("points_count", shader_points.Count);

    }
    void SetClusters(out ComputeBuffer clusters_buffer)
    {
        List<MyCluster> shader_clusters = new List<MyCluster>();
        foreach (ClusterInfo cluster in clusters)
        {
            MyCluster new_cluster = new MyCluster();

            new_cluster.position_x = cluster.Position.Vector[x_axis_index];
            new_cluster.position_y = cluster.Position.Vector[y_axis_index];
            new_cluster.cluster_index = cluster.ClusterIndex;
            new_cluster.color_a = cluster.color.a;
            new_cluster.color_r = cluster.color.r;
            new_cluster.color_g = cluster.color.g;
            new_cluster.color_b = cluster.color.b;

            shader_clusters.Add(new_cluster);
        }
        clusters_buffer = new ComputeBuffer(shader_clusters.Count, shader_clusters.Count * MyClusterSize);

        clusters_buffer.SetData(shader_clusters.ToArray());
        main_compute_shader.SetBuffer(0, "clusters", clusters_buffer);
        main_compute_shader.SetInt("clusters_count", shader_clusters.Count);
    }
    Vector2 canvas_position = Vector2.zero;
    Vector2 canvas_scale = Vector2.one;
    void UpdateShader()
    {
        ComputeBuffer clusters_buffer;
        ComputeBuffer points_buffer;

        SetPoints(out points_buffer);
        SetClusters(out clusters_buffer);



        main_render_texture.enableRandomWrite = true;
        main_render_texture.Create();
        main_compute_shader.SetTexture(0, "Result", main_render_texture);

        main_compute_shader.SetVector("canvas_position", canvas_position);

        main_compute_shader.SetVector("canvas_resolution", new Vector4(main_render_texture.width, main_render_texture.height, 0, 0));
        main_compute_shader.SetVector("canvas_size", new Vector4(8 * canvas_scale.x, 8 * canvas_scale.y, 0, 0));

        main_compute_shader.Dispatch(0, main_render_texture.width / 8, main_render_texture.height / 8, 1);

        clusters_buffer.Release();
        points_buffer.Release();
    }
    private void Update()
    {
        PlayerInput();
    }
    const float map_move_delta = 5;
    const float map_scale_delta = 1.001f;
    void PlayerInput()
    {
        bool is_changed = false;
        if (Input.GetKey(KeyCode.W))
        {
            canvas_position.y += map_move_delta * Time.deltaTime;
            is_changed = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            canvas_position.x -= map_move_delta * Time.deltaTime;
            is_changed = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            canvas_position.y -= map_move_delta * Time.deltaTime;
            is_changed = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            canvas_position.x += map_move_delta * Time.deltaTime;
            is_changed = true;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            canvas_scale.x *= map_scale_delta;
            canvas_scale.y *= map_scale_delta;
            is_changed = true;
        }
        if (Input.GetKey(KeyCode.E))
        {
            canvas_scale.x /= map_scale_delta;
            canvas_scale.y /= map_scale_delta;
            is_changed = true;
        }

        if (is_changed)
            UpdateShader();
    }
    public void CalculateNextStep()
    {
        if (current_algorithm == null)
            return;

        if (points == null)
            return;

        if (clusters == null)
            return;

        current_algorithm.ExecuteAlgorithm(ref points, ref clusters);
        UpdateShader();
    }
    public void CalculateFullSolution()
    {
        if (current_algorithm == null)
            return;

        if (points == null)
            return;

        if (clusters == null)
            return;

        bool is_continue_loop = true;
        do
        {
            List<NVector> cluster_old_pos = new List<NVector>();

            foreach (ClusterInfo cluster in clusters)
                cluster_old_pos.Add(cluster.Position);

            CalculateNextStep();

            is_continue_loop = false;
            for (int i = 0; i < clusters.Count; i++)
            {
                bool inner_loop_switch = false;
                for(int j = 0; j < clusters[i].Position.Vector.Length;j++)
                {
                    if (clusters[i].Position.Vector[j] != cluster_old_pos[i].Vector[j])
                    {
                        is_continue_loop = true;
                        inner_loop_switch = true;
                        break;
                    }
                    
                }
                if (inner_loop_switch)
                    break;
            }
        }
        while(is_continue_loop);
    }
    public void AddNewPoint(List<float> new_point)
    {
        if (points == null)
            points = new List<ClusterPoint>();

        points.Add(new ClusterPoint(new NVector(new_point.ToArray()), -1));
        UpdateShader();
    }
}
