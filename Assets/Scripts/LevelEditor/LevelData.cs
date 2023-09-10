using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelData
{
    public float[][][] Barrier;
    public bool[][] BarrierOptions;
    public int[] BarrierColor;
    public float[][][] Player;
    public float[][][] Purple;
    public float[][][] Magenta;
    public bool[][] PurpleOptions;    
    public bool[][] MagentaOptions;
    public float[][][] BadBeanBarrier;
    public bool[][] BadBeanBarrierOptions;
    public float[][][] Finish;
    public float[][][] Jump;
    public float DownestObjectInGame;

    public LevelData()
    {
        int l = 0;
        {
            int j = 0;
            foreach (var item in GameObject.FindGameObjectsWithTag("Barrier"))
            {
                Array.Resize(ref Barrier, j + 1);
                Array.Resize(ref Barrier[j], 3);
                Array.Resize(ref Barrier[j][0], 3);
                Array.Resize(ref Barrier[j][1], 3);
                Array.Resize(ref Barrier[j][2], 3);
                Array.Resize(ref BarrierOptions, j + 1);
                Array.Resize(ref BarrierOptions[j], 3);
                Array.Resize(ref BarrierColor, j + 1);
                Barrier[j][0][0] = item.transform.position.x;
                Barrier[j][0][1] = item.transform.position.y;
                Barrier[j][0][2] = item.transform.position.z;
                Barrier[j][1][0] = item.transform.rotation.eulerAngles.x;
                Barrier[j][1][1] = item.transform.rotation.eulerAngles.y;
                Barrier[j][1][2] = item.transform.rotation.eulerAngles.z;
                Barrier[j][2][0] = item.transform.localScale.x;
                Barrier[j][2][1] = item.transform.localScale.y;
                Barrier[j][2][2] = item.transform.localScale.z;
                BarrierOptions[j][0] = item.GetComponent<ObjectsOptions>().NoClip;
                BarrierOptions[j][1] = item.GetComponent<ObjectsOptions>().Invisible;
                BarrierOptions[j][2] = item.GetComponent<ObjectsOptions>().KillPlayer;
                BarrierColor[j] = (int)item.GetComponent<ObjectsOptions>().Color;
                if (DownestObjectInGame > item.transform.position.y || l == 0)
                    DownestObjectInGame = item.transform.position.y;
                l++;
                j++;
            }
        }
        {
            int j = 0;
            foreach (var item in GameObject.FindGameObjectsWithTag("BadBeanBarrier"))
            {
                Array.Resize(ref BadBeanBarrier, j + 1);
                Array.Resize(ref BadBeanBarrier[j], 3);
                Array.Resize(ref BadBeanBarrier[j][0], 3);
                Array.Resize(ref BadBeanBarrier[j][1], 3);
                Array.Resize(ref BadBeanBarrier[j][2], 3);
                Array.Resize(ref BadBeanBarrierOptions, j + 1);
                Array.Resize(ref BadBeanBarrierOptions[j], 1);
                BadBeanBarrier[j][0][0] = item.transform.position.x;
                BadBeanBarrier[j][0][1] = item.transform.position.y;
                BadBeanBarrier[j][0][2] = item.transform.position.z;
                BadBeanBarrier[j][1][0] = item.transform.rotation.eulerAngles.x;
                BadBeanBarrier[j][1][1] = item.transform.rotation.eulerAngles.y;
                BadBeanBarrier[j][1][2] = item.transform.rotation.eulerAngles.z;
                BadBeanBarrier[j][2][0] = item.transform.localScale.x;
                BadBeanBarrier[j][2][1] = item.transform.localScale.y;
                BadBeanBarrier[j][2][2] = item.transform.localScale.z;
                BadBeanBarrierOptions[j][0] = item.GetComponent<ObjectsOptions>().NoClip;
                if (DownestObjectInGame > item.transform.position.y || l == 0)
                    DownestObjectInGame = item.transform.position.y;
                l++;
                j++;
            }
        }
        {
            int j = 0;
            foreach (var item in GameObject.FindGameObjectsWithTag("Finish"))
            {
                Array.Resize(ref Finish, j + 1);
                Array.Resize(ref Finish[j], 3);
                Array.Resize(ref Finish[j][0], 3);
                Array.Resize(ref Finish[j][1], 3);
                Array.Resize(ref Finish[j][2], 3);
                Finish[j][0][0] = item.transform.position.x;
                Finish[j][0][1] = item.transform.position.y;
                Finish[j][0][2] = item.transform.position.z;
                Finish[j][1][0] = item.transform.rotation.eulerAngles.x;
                Finish[j][1][1] = item.transform.rotation.eulerAngles.y;
                Finish[j][1][2] = item.transform.rotation.eulerAngles.z;
                Finish[j][2][0] = item.transform.localScale.x;
                Finish[j][2][1] = item.transform.localScale.y;
                Finish[j][2][2] = item.transform.localScale.z;
                if (DownestObjectInGame > item.transform.position.y || l == 0)
                    DownestObjectInGame = item.transform.position.y;
                l++;
                j++;
            }
        }
        {
            int j = 0;
            foreach (var item in GameObject.FindGameObjectsWithTag("Player"))
            {
                Array.Resize(ref Player, j + 1);
                Array.Resize(ref Player[j], 3);
                Array.Resize(ref Player[j][0], 3);
                Array.Resize(ref Player[j][1], 3);
                Array.Resize(ref Player[j][2], 3);
                Player[j][0][0] = item.transform.position.x;
                Player[j][0][1] = item.transform.position.y;
                Player[j][0][2] = item.transform.position.z;
                l++;
                j++;
            }
        }
        {
            int j = 0;
            foreach (var item in GameObject.FindGameObjectsWithTag("Friend"))
            {
                Array.Resize(ref Purple, j + 1);
                Array.Resize(ref Purple[j], 3);
                Array.Resize(ref Purple[j][0], 3);
                Array.Resize(ref Purple[j][1], 3);
                Array.Resize(ref Purple[j][2], 3);
                Array.Resize(ref PurpleOptions, j + 1);
                Array.Resize(ref PurpleOptions[j], 2);
                Purple[j][0][0] = item.transform.position.x;
                Purple[j][0][1] = item.transform.position.y;
                Purple[j][0][2] = item.transform.position.z;
                PurpleOptions[j][0] = item.GetComponent<ObjectsOptions>().NoClip;
                PurpleOptions[j][1] = item.GetComponent<ObjectsOptions>().Invisible;
                l++;
                j++;
            }
        }        
        {
            int j = 0;
            foreach (var item in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Array.Resize(ref Magenta, j + 1);
                Array.Resize(ref Magenta[j], 3);
                Array.Resize(ref Magenta[j][0], 3);
                Array.Resize(ref Magenta[j][1], 3);
                Array.Resize(ref Magenta[j][2], 3);
                Array.Resize(ref MagentaOptions, j + 1);
                Array.Resize(ref MagentaOptions[j], 2);
                Magenta[j][0][0] = item.transform.position.x;
                Magenta[j][0][1] = item.transform.position.y;
                Magenta[j][0][2] = item.transform.position.z;
                MagentaOptions[j][0] = item.GetComponent<ObjectsOptions>().NoClip;
                MagentaOptions[j][1] = item.GetComponent<ObjectsOptions>().Invisible;
                l++;
                j++;
            }
        }
        {
            int j = 0;
            foreach (var item in GameObject.FindGameObjectsWithTag("Jump"))
            {
                Array.Resize(ref Jump, j + 1);
                Array.Resize(ref Jump[j], 3);
                Array.Resize(ref Jump[j][0], 3);
                Array.Resize(ref Jump[j][1], 3);
                Array.Resize(ref Jump[j][2], 3);
                Jump[j][0][0] = item.transform.position.x;
                Jump[j][0][1] = item.transform.position.y;
                Jump[j][0][2] = item.transform.position.z;
                Jump[j][1][0] = item.transform.rotation.eulerAngles.x;
                Jump[j][1][1] = item.transform.rotation.eulerAngles.y;
                Jump[j][1][2] = item.transform.rotation.eulerAngles.z;
                Jump[j][2][0] = item.transform.localScale.x;
                Jump[j][2][1] = item.transform.localScale.z;
                l++;
                j++;
            }
        }
    }

}
