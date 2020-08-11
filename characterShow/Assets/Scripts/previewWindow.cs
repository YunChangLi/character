using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[CustomEditor(typeof(preview))]
public class previewWindow : Editor
{
    public override bool HasPreviewGUI()
    {
        return true;
    }
    public override GUIContent GetPreviewTitle()
    {
        return new GUIContent("designPlayer");
    }
}
