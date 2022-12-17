using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct NVector
{
    float[] vector;
    public float[] Vector
    {
        get => vector;
        set => vector = value;
    }
    public float? GetVectorAxis(int axis_index)
    {
        if (vector == null)
            return null;

        if (axis_index < 0)
            return null;

        if (axis_index >= vector.Length)
            return null;

        return vector[axis_index];
    }

    public NVector(float[] vector) => this.vector = vector;
}
