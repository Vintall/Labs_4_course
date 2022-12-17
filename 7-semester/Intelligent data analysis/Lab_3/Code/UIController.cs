using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using System.IO;

public class UIController : MonoBehaviour
{
    static UIController instance;
    public static UIController Instance => instance;

    [SerializeField] TMP_Dropdown algorithm_dropdown;
    [SerializeField] GameObject axis_value_asset;
    [SerializeField] RectTransform content_transform;

    [SerializeField] TMP_Dropdown x_axis_dropdown;
    [SerializeField] TMP_Dropdown y_axis_dropdown;

    List<UIVectorAxisValue> axis_fields = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        InitializeVectorField(GameController.VectorSize);
    }

    [SerializeField] TMP_InputField points_file_path_input;
    [SerializeField] TMP_InputField clusters_file_path_input;


    public void InitializeGraphicsAxis(List<string> possible_axis)
    {
        x_axis_dropdown.options.Clear();
        y_axis_dropdown.options.Clear();

        foreach (string axis in possible_axis)
        {
            x_axis_dropdown.options.Add(new TMP_Dropdown.OptionData(axis));
            y_axis_dropdown.options.Add(new TMP_Dropdown.OptionData(axis));
        }
        if (x_axis_dropdown.options.Count > 0)
            x_axis_dropdown.value = 0;
        if (y_axis_dropdown.options.Count > 0)
            y_axis_dropdown.value = 0;
    }
    public void InitializeVectorField(int vector_size)
    {
        if (axis_fields == null)
            axis_fields = new List<UIVectorAxisValue>();

        foreach(UIVectorAxisValue field in axis_fields)
            Destroy(field.gameObject);

        axis_fields.Clear();

        for (int i = 0; i < vector_size; i++)
        {
            UIVectorAxisValue new_field = Instantiate(axis_value_asset, content_transform).GetComponent<UIVectorAxisValue>();
            new_field.InitializeField(i + 1);
            axis_fields.Add(new_field);
        }
    }
    public void FileExplorerButtonPressed(string type)
    {
        string file_extention = "";
        switch (type)
        {
            case "PointsInfo":
                file_extention = "PLF"; // .PointsListFile
                break;
            case "ClustersInfo":
                file_extention = "CLF"; // .ClustersListFile
                break;
        }

        string file_path = EditorUtility.OpenFilePanel($"Input \".{file_extention}\" File", Application.dataPath + "../Data", file_extention);

        if (!File.Exists(file_path))
            return;


        switch (type)
        {
            case "PointsInfo":
                points_file_path_input.text = file_path;
                break;
            case "ClustersInfo":
                clusters_file_path_input.text = file_path;
                break;
        }
    }

    public List<float> NewPointAxisFieldValues
    {
        get
        {
            List<float> result = new List<float>();

            foreach(UIVectorAxisValue value in axis_fields)
            {
                float out_value;

                if (!float.TryParse(value.InputField.text, out out_value))
                    return null;

                result.Add(out_value);
            }

            return result;
        }
    }
    public void OnImportFileButtonPressed(string type)
    {
        string[] file_lines = new string[0];
        switch (type)
        {
            case "PointsInfo":
                if (!File.Exists(points_file_path_input.text))
                    return;

                file_lines = File.ReadAllLines(points_file_path_input.text);

                GameController.Instance.ImportPointsFromFile(file_lines);
                break;
            case "ClustersInfo":
                if (!File.Exists(clusters_file_path_input.text))
                    return;

                file_lines = File.ReadAllLines(clusters_file_path_input.text);

                GameController.Instance.ImportClustersFromFile(file_lines);
                break;
        }

        
    }

    public void OnAxisValueChanged() => GameController.Instance.ChangeAxis(x_axis_dropdown.value, y_axis_dropdown.value);
    public void OnExecuteAlgorithmButtonPressed() => GameController.Instance.ExecuteClassificationAlgorithm(algorithm_dropdown.options[algorithm_dropdown.value].text);
    public void OnNextStepButtonPressed() => GameController.Instance.CalculateNextStep();
    public void OnCalculateButtonPressed() => GameController.Instance.CalculateFullSolution();
    public void OnAddPointButtonPressed() => GameController.Instance.AddNewPoint(NewPointAxisFieldValues);
}