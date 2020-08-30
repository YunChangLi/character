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

    public Vector3 Offset { get; set; }
    public float Radius { get; set; }
    public bool IsShowRange { get; set; }

    private void OnDrawGizmos()
    {
        if (!IsShowRange)
            return;
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position + Offset, Radius);
    }
}
