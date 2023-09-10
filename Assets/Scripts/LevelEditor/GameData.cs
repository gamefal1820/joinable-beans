using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.AI; 
using UnityEngine;

public class GameData : MonoBehaviour
{
    public GameObject Barrier;
    public GameObject Purple;    
    public GameObject Magenta;
    public GameObject BadBeanBarrier;
    public GameObject Finish;
    public GameObject Jump;
    [SerializeField] Material[] ObjectMaterials;

    private void Start()
    {
        LevelData levelData = null;
        if (GameObject.Find("temp(Clone)"))
        {
            levelData = SaveSystem.LoadtempLevel();
            string path = Application.persistentDataPath + @"\temp";
            if (File.Exists(path + @"\data"))
                File.Delete(path + @"\data");
            if (File.Exists(path + @"\datatemp"))
                File.Delete(path + @"\datatemp");
            if (File.Exists(path + @"\icon.png"))
                File.Delete(path + @"\icon.png");
            if (File.Exists(path + @"\objects"))
                File.Delete(path + @"\objects");
            Destroy(GameObject.Find("temp(Clone)"));
            foreach (var item in GameObject.FindGameObjectsWithTag("Barrier"))
            {
                Destroy(item);
            }
        }
        else if (GameObject.Find("CustomLevelManager").GetComponent<CustomLevelManage>().IsEdit)
        {
            levelData = SaveSystem.LoadLevel();
            foreach (var item in GameObject.FindGameObjectsWithTag("Barrier"))
            {
                Destroy(item);
            }
        }

        if (levelData != null)
        {
            if (levelData.Barrier != null)
            {
                for (int i = 0; i < levelData.Barrier.Length; i++)
                {
                    GameObject thegameobject = Instantiate(Barrier, new Vector3(levelData.Barrier[i][0][0], levelData.Barrier[i][0][1],
    levelData.Barrier[i][0][2]), Quaternion.Euler(levelData.Barrier[i][1][0], levelData.Barrier[i][1][1],
    levelData.Barrier[i][1][2]));

                    thegameobject.transform.localScale = new Vector3(levelData.Barrier[i][2][0], levelData.Barrier[i][2][1], levelData.Barrier[i][2][2]);

                    thegameobject.GetComponent<Renderer>().material = ObjectMaterials[levelData.BarrierColor[i]];
                    thegameobject.GetComponent<ObjectsOptions>().Color = (ObjectsOptions.ObjectColors)levelData.BarrierColor[i];
                    //if (l == 0 || lowestGameObject > levelData.Barrier[i][0][1])
                    //{
                    //	lowestGameObject = levelData.Barrier[i][0][1];
                    //}

                    thegameobject.GetComponent<ObjectsOptions>().NoClip = levelData.BarrierOptions[i][0];
                    thegameobject.GetComponent<ObjectsOptions>().Invisible = levelData.BarrierOptions[i][1];
                    thegameobject.GetComponent<ObjectsOptions>().KillPlayer = levelData.BarrierOptions[i][2];


                    //l++;
                }
            }
            if (levelData.BadBeanBarrier != null)
            {
                for (int i = 0; i < levelData.BadBeanBarrier.Length; i++)
                {
                    GameObject thegameobject = Instantiate(BadBeanBarrier, new Vector3(levelData.BadBeanBarrier[i][0][0], levelData.BadBeanBarrier[i][0][1],
    levelData.BadBeanBarrier[i][0][2]), Quaternion.Euler(levelData.BadBeanBarrier[i][1][0], levelData.BadBeanBarrier[i][1][1],
    levelData.BadBeanBarrier[i][1][2]));

                    thegameobject.transform.localScale = new Vector3(levelData.BadBeanBarrier[i][2][0], levelData.BadBeanBarrier[i][2][1], levelData.BadBeanBarrier[i][2][2]);
                    thegameobject.GetComponent<ObjectsOptions>().NoClip = levelData.BadBeanBarrierOptions[i][0];
                    //if (l == 0 || lowestGameObject > levelData.BadBeanBarrier[i][0][1])
                    //{
                    //	lowestGameObject = levelData.BadBeanBarrier[i][0][1];
                    //}
                    //l++;
                }
            }
            if (levelData.Finish != null)
            {
                for (int i = 0; i < levelData.Finish.Length; i++)
                {
                    GameObject thegameobject = Instantiate(Finish, new Vector3(levelData.Finish[i][0][0], levelData.Finish[i][0][1],
                    levelData.Finish[i][0][2]), Quaternion.Euler(levelData.Finish[i][1][0], levelData.Finish[i][1][1],
                    levelData.Finish[i][1][2]));
                    thegameobject.transform.localScale = new Vector3(levelData.Finish[i][2][0], levelData.Finish[i][2][1], levelData.Finish[i][2][2]);
                    //if (l == 0 || lowestGameObject > levelData.Finish[i][0][1])
                    //{
                    //	lowestGameObject = levelData.Finish[i][0][1];
                    //}
                    //l++;
                }
            }
            if (levelData.Purple != null)
            {
                for (int i = 0; i < levelData.Purple.Length; i++)
                {
                    GameObject thegameobject = Instantiate(Purple, new Vector3(levelData.Purple[i][0][0], levelData.Purple[i][0][1],
                    levelData.Purple[i][0][2]), Quaternion.Euler(levelData.Purple[i][1][0], levelData.Purple[i][1][1],
                    levelData.Purple[i][1][2]));
                    thegameobject.GetComponent<ObjectsOptions>().NoClip = levelData.PurpleOptions[i][0];
                    thegameobject.GetComponent<ObjectsOptions>().Invisible = levelData.PurpleOptions[i][1];
                }
            }            
            if (levelData.Magenta != null)
            {
                for (int i = 0; i < levelData.Magenta.Length; i++)
                {
                    GameObject thegameobject = Instantiate(Magenta, new Vector3(levelData.Magenta[i][0][0], levelData.Magenta[i][0][1],
                    levelData.Magenta[i][0][2]), Quaternion.Euler(levelData.Magenta[i][1][0], levelData.Magenta[i][1][1],
                    levelData.Magenta[i][1][2]));
                    thegameobject.GetComponent<ObjectsOptions>().NoClip = levelData.MagentaOptions[i][0];
                    thegameobject.GetComponent<ObjectsOptions>().Invisible = levelData.MagentaOptions[i][1];
                }
            }
            GameObject.Find("MainBean").transform.position = new Vector3(levelData.Player[0][0][0], levelData.Player[0][0][1], levelData.Player[0][0][2]);

            if (levelData.Jump != null)
            {
                for (int i = 0; i < levelData.Jump.Length; i++)
                {
                    GameObject thegameobject = Instantiate(Jump , new Vector3(levelData.Jump[i][0][0], levelData.Jump[i][0][1],
    levelData.Jump[i][0][2]), Quaternion.Euler(levelData.Jump[i][1][0], levelData.Jump[i][1][1],
    levelData.Jump[i][1][2]));

                    thegameobject.transform.localScale = new Vector3(levelData.Jump[i][2][0], 0.1f, levelData.Jump[i][2][1]);
                }
            }

        }
    }


}
