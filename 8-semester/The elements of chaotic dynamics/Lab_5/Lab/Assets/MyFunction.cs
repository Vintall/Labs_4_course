using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFunction
{

    // Mine (7)
    //public static float X(Vector3 position) => 4000 - position.y * position.y * 10000;
    //public static float Y(Vector3 position) => position.y + 10 * position.z + position.x * (position.y + 4 / 3 * position.z);
    //public static float Z(Vector3 position) => -10 * position.y + position.z + position.x * (-4 / 3 * position.y + position.z);


    // 14
    public static float X(Vector3 position) => -position.y * position.y + position.z * position.z;
    public static float Y(Vector3 position) => -position.y - 250 * position.z + 10 * position.x * position.y;
    public static float Z(Vector3 position) => position.x + 250 * position.y - position.z - 15 * position.x * position.z;


    //13
    //public static float X(Vector3 p) => 3f * p.x + p.x * (p.x - 3f) * (5 * p.y * p.y - p.z * p.z) / (1 + p.y * p.y + p.z + p.z);
    //public static float Y(Vector3 p) => 2 * p.y - 14 * p.z - 5 * (p.x - 3) * p.y;
    //public static float Z(Vector3 p) => 14 * p.y + 2 * p.z + 5 * (p.x - 3) * p.z;

    //9
    //public static float X(Vector3 p) => 1.23f * p.x - 0.6f * p.y + 0.69f * p.z + p.y * p.y - p.z * p.z;
    //public static float Y(Vector3 p) => -1.38f * p.x - 1.4f * p.y + 1.15f * p.z - p.x * p.y;
    //public static float Z(Vector3 p) => -3.5f * p.x - 2f * p.y + 1.6f * p.z + p.x * p.z;

    public static Vector3 XYZ(Vector3 position) => new Vector3(X(position), Y(position), Z(position));
}
