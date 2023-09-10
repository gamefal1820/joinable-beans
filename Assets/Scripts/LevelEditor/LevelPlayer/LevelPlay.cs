using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using eDmitriyAssets.NavmeshLinksGenerator;

public class LevelPlay : MonoBehaviour
{
    public GameObject Barrier;
    public GameObject Purple;    
    public GameObject Magenta;
    public GameObject BadBeanBarrier;
    public GameObject Finish;
    public GameObject Jump;
    [SerializeField] Material[] ObjectMaterials;
    float lowestGameObject;
    public bool Playing;
    Transform Player;
    public NavMeshSurface surface;
    public NavMeshLinks_AutoPlacer autoplace;

    private void Awake()
    {
        
        Player = GameObject.Find("MainBean").transform;
        Playing = false;
        Time.timeScale = 0;
        LevelData levelData;
        if (GameObject.Find("temp(Clone)"))
        {
            GameObject.Find("Canvas").transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>().text = "Back to level Editor";
            GameObject.Find("Canvas").transform.GetChild(0).GetChild(2).GetComponent<Button>().onClick.RemoveAllListeners();
            GameObject.Find("Canvas").transform.GetChild(0).GetChild(2).GetComponent<Button>().onClick.AddListener(delegate { LoadLevelEditor(); });
            GameObject.Find("Canvas").transform.GetChild(2).GetChild(3).GetChild(0).GetComponent<Text>().text = "Back to level Editor";
            GameObject.Find("Canvas").transform.GetChild(2).GetChild(3).GetComponent<Button>().onClick.RemoveAllListeners();
            GameObject.Find("Canvas").transform.GetChild(2).GetChild(3).GetComponent<Button>().onClick.AddListener(delegate { LoadLevelEditor(); });
            GameObject.Find("Canvas").transform.GetChild(3).GetChild(2).GetChild(0).GetComponent<Text>().text = "Back to level Editor";
            GameObject.Find("Canvas").transform.GetChild(3).GetChild(2).GetComponent<Button>().onClick.RemoveAllListeners();
            GameObject.Find("Canvas").transform.GetChild(3).GetChild(2).GetComponent<Button>().onClick.AddListener(delegate { LoadLevelEditor(); });
            levelData = SaveSystem.LoadtempLevel();
        }
        else
        {
            levelData = SaveSystem.LoadLevel();
        }


        //int l = 0;
        if (levelData.Barrier != null)
        {
            for (int i = 0; i < levelData.Barrier.Length; i++)
            {
                GameObject thegameobject = Instantiate(Barrier, new Vector3(levelData.Barrier[i][0][0], levelData.Barrier[i][0][1],
levelData.Barrier[i][0][2]), Quaternion.Euler(levelData.Barrier[i][1][0], levelData.Barrier[i][1][1],
levelData.Barrier[i][1][2]));

                thegameobject.transform.localScale = new Vector3(levelData.Barrier[i][2][0], levelData.Barrier[i][2][1], levelData.Barrier[i][2][2]);

                thegameobject.GetComponent<Renderer>().material = ObjectMaterials[levelData.BarrierColor[i]];
                //if (l == 0 || lowestGameObject > levelData.Barrier[i][0][1])
                //{
                //	lowestGameObject = levelData.Barrier[i][0][1];
                //}

                thegameobject.GetComponent<Collider>().isTrigger = levelData.BarrierOptions[i][0];
                thegameobject.GetComponent<Renderer>().enabled = !levelData.BarrierOptions[i][1];
                if (levelData.BarrierOptions[i][2])
                {
                    thegameobject.GetComponent<Collider>().isTrigger = levelData.BarrierOptions[i][2];
                    thegameobject.GetComponent<DeadZone>().enabled = levelData.BarrierOptions[i][2];
                }

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
                thegameobject.GetComponent<Collider>().isTrigger = levelData.BadBeanBarrierOptions[i][0];
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
        surface.BuildNavMesh();
        autoplace.Generate();
        if (levelData.Purple != null)
        {
            for (int i = 0; i < levelData.Purple.Length; i++)
            {
                GameObject thegameobject = Instantiate(Purple, new Vector3(levelData.Purple[i][0][0], levelData.Purple[i][0][1],
                levelData.Purple[i][0][2]), Quaternion.Euler(levelData.Purple[i][1][0], levelData.Purple[i][1][1],
                levelData.Purple[i][1][2]));
                    thegameobject.GetComponent<Collider>().isTrigger = levelData.PurpleOptions[i][0];
                thegameobject.GetComponent<Renderer>().enabled = !levelData.PurpleOptions[i][1];
                print(levelData.PurpleOptions[i][0]);
                print(levelData.PurpleOptions[i][1]);
            }
        }        
        if (levelData.Magenta != null)
        {
            for (int i = 0; i < levelData.Magenta.Length; i++)
            {
                GameObject thegameobject = Instantiate(Magenta, new Vector3(levelData.Magenta[i][0][0], levelData.Magenta[i][0][1],
                levelData.Magenta[i][0][2]), Quaternion.Euler(levelData.Magenta[i][1][0], levelData.Magenta[i][1][1],
                levelData.Magenta[i][1][2]));
                    thegameobject.GetComponent<Collider>().isTrigger = levelData.MagentaOptions[i][0];
                thegameobject.GetComponent<Renderer>().enabled = !levelData.MagentaOptions[i][1];
                print(levelData.MagentaOptions[i][0]);
                print(levelData.MagentaOptions[i][1]);
            }
        }
        if (levelData.Jump != null)
        {
            for (int i = 0; i < levelData.Jump.Length; i++)
            {
                GameObject thegameobject = Instantiate(Jump, new Vector3(levelData.Jump[i][0][0], levelData.Jump[i][0][1],
levelData.Jump[i][0][2]), Quaternion.Euler(levelData.Jump[i][1][0], levelData.Jump[i][1][1],
levelData.Jump[i][1][2]));

                thegameobject.GetComponent<NavMeshLink>().startPoint = new Vector3(-levelData.Jump[i][2][0] / 2, 0, 0);
                thegameobject.GetComponent<NavMeshLink>().endPoint = new Vector3(levelData.Jump[i][2][0] / 2, 0, 0);
                thegameobject.GetComponent<NavMeshLink>().width = levelData.Jump[i][2][1];

            }
        }

        GameObject.Find("MainBean").GetComponent<CharacterController>().enabled = false;
        GameObject.Find("MainBean").GetComponent<BeanMovement>().enabled = false;
        GameObject.Find("MainBean").transform.position = new Vector3(levelData.Player[0][0][0], levelData.Player[0][0][1], levelData.Player[0][0][2]);
        GameObject.Find("MainBean").GetComponent<CharacterController>().enabled = true;
        GameObject.Find("MainBean").GetComponent<BeanMovement>().enabled = true;

        lowestGameObject = levelData.DownestObjectInGame;
    }
    bool GamePanActivate;


    void Update()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
		GameObject.Find("Canvas").transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "Tap screen to play";
		if (Input.touchCount <= 1)
		{
			Playing = true;
		}
#endif
#if UNITY_STANDALONE || UNITY_EDITOR
        if (Input.anyKey)
        {
            Playing = true;
        }
#endif
        if (Playing)
        {
#if UNITY_ANDROID
			if (!GamePanActivate)
			{
				GamePanActivate = true;
				GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);
				GameObject.Find("AudiosGame").transform.GetChild(0).GetComponent<AudioSource>().Play();
			}

#endif
            if (!GamePanActivate)
            {
                GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(false);
                Time.timeScale = 1;
                GameObject.Find("AudiosGame").transform.GetChild(0).GetComponent<AudioSource>().Play();
                GamePanActivate = true;
            }
            if (Player.position.y < lowestGameObject - 3)
            {
                print("dead");
                DeadZone.BeingDead();
            }
        }
    }

    public void LoadLevelEditor()
    {
        SceneManager.LoadScene("LevelEditor");
    }
}
