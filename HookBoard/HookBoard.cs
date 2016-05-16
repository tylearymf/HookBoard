using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using UnityEngine;

public class HookBoard
{
    private HookBoardLib _keyboardHook = null;
    private Keys key;
    public bool SetDebugLog { set { setDebugLog = value; } }
    private bool setDebugLog = false;

    public bool SetEnableHook
    {
        set { setEnableHook = value; }
    }
    private bool setEnableHook = false;
    public void InstallHook()
    {
        _keyboardHook = new HookBoardLib();
        _keyboardHook.InstallHook(this.OnKeyPress);
    }

    public void UninstallHook()
    {
        if (_keyboardHook != null)
        {
            _keyboardHook.UninstallHook();
        }
    }

    private void OnKeyPress(HookBoardLib.HookStruct hookStruct, out bool handle)
    {
        handle = false; //预设不拦截任何键 

        if (setEnableHook)
        {
            if (hookStruct.vkCode == 91) // 截获左win(开始菜单键)
            {
                handle = true;
            }

            if (hookStruct.vkCode == 92)// 截获右win
            {
                handle = true;
            }

            //截获Ctrl+Esc 
            if (hookStruct.vkCode == (int)Keys.Escape && (int)Control.ModifierKeys == (int)Keys.Control)
            {
                handle = true;
            }

            //截获alt+f4 
            if (hookStruct.vkCode == (int)Keys.F4 && (int)Control.ModifierKeys == (int)Keys.Alt)
            {
                handle = true;
            }

            //截获alt+tab 
            if (hookStruct.vkCode == (int)Keys.Tab && (int)Control.ModifierKeys == (int)Keys.Alt)
            {
                handle = true;
            }

            //截获F1 
            if (hookStruct.vkCode == (int)Keys.F1)
            {
                handle = true;
            }
                                                  
            //截获Ctrl+Alt+Delete
            if (hookStruct.vkCode == (int)Keys.Delete && (int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Alt)
            {
                handle = true;
            }
        }
        ////如果键A~Z 
        //if (hookStruct.vkCode >= (int)Keys.A && hookStruct.vkCode <= (int)Keys.Z)
        //{
        //    //挡掉B键 
        //    if (hookStruct.vkCode == (int)Keys.B)
        //        hookStruct.vkCode = (int)Keys.None; //设键为0 
        //    handle = true;
        //}

        ////拦截PrintScreen
        //if (hookStruct.vkCode == (int)Keys.PrintScreen)
        //{
        //    handle = true;
        //}

        //Keys key = (Keys)hookStruct.vkCode;
        //label1.Text = "你按下：" + (key == Keys.None ? "" : key.ToString());
        key = (Keys)hookStruct.vkCode;
        if (setDebugLog)
            Debug.Log("你按下：" + (key == Keys.None ? "" : key.ToString()));
    }
}

