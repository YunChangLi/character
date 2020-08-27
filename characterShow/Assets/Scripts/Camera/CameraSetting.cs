using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    //是否invert x,y
    [Serializable] //visible the struct setting in Inspector
    public struct InvertSetting 
    {
        public bool InvertX;
        public bool InvertY;
    }
    //相機跟隨的對象
    public Transform CameraFollow;
    //相機看的目標
    public Transform CameraLookAt;
    //引入相機設定參數
    public CinemachineFreeLook FreeLook;
    //bool inverSetting
    public InvertSetting InvertSet;
    //can adjust the camera setting during playing game
    public bool IsRunTimeSetTheCamera;


    // Start is called before the first frame update

    private void Awake()
    {
        UpdateFreeLookSetting(); //may put in the Init in  Player Manager
    }
    // Update is called once per frame
    void Update()
    {
        if(IsRunTimeSetTheCamera)
            UpdateFreeLookSetting();
    }
    private void UpdateFreeLookSetting() 
    {
        FreeLook.Follow = CameraFollow;
        FreeLook.LookAt = CameraLookAt;
        FreeLook.m_XAxis.m_InvertInput = InvertSet.InvertX;
        FreeLook.m_YAxis.m_InvertInput = InvertSet.InvertY;
    } 
}
