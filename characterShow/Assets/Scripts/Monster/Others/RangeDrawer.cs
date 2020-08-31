using NodeEditorFramework.Standard;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RangeDrawer : MonoBehaviour
{
    /// <summary>
    /// 協助繪製Gzimos範圍的Script
    /// </summary>

    public enum RangeType
    {
        Box,
        Sphere
    }

    public Vector3 Offset { get; set; }
    public bool IsShowRange { get; set; }

    // 圓球形參數
    public float Radius { get; set; }

    // 方形參數
    public Vector3 Size { get; set; }

    public RangeType DrawRangeType { get; set; }

    private void OnDrawGizmos()
    {
        if (!IsShowRange)
            return;
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        // 根據角色的旋轉計算新的中心位置
        Vector3 newCenter = Quaternion.AngleAxis(transform.rotation.eulerAngles.y, Vector3.up) * Offset;
        if (DrawRangeType == RangeType.Sphere) 
        {
            Gizmos.DrawSphere(transform.position + newCenter, Radius);
        }
        else 
        {
            Gizmos.matrix = Matrix4x4.TRS(transform.position + newCenter, transform.rotation, Size * 2);
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        }
    }
}
