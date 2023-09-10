using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.AI;

public class DetialsManager : MonoBehaviour
{
    [SerializeField] List<Transform> Panels;
    [SerializeField] Material[] ObjectMaterials;
    public float MovementSpeed = 10;
    public static bool ButtonHelding;
    int demintion;

    private void Awake()
    {
        foreach (GameObject item in Resources.FindObjectsOfTypeAll<GameObject>())
        {
            if (item.name == "Canvas")
            {
                for (int i = 0; i < item.transform.GetChild(1).GetChild(1).childCount; i++)
                {
                    Panels.Add(item.transform.GetChild(1).GetChild(1).GetChild(i));
                }
            }

        }
    }
    public void OnEnable()
    {
        ObjectsOptions options = SelectionManager.Selection.GetComponent<ObjectsOptions>();
        foreach (var item in Panels)
        {
            if (SelectionManager.Selection != null)
            {
                if (SelectionManager.Selection.CompareTag("Barrier"))
                {
                    transform.GetChild(0).GetChild(3).GetComponent<Toggle>().isOn = options.NoClip;
                    transform.GetChild(0).GetChild(4).GetComponent<Toggle>().isOn = options.Invisible;
                    transform.GetChild(0).GetChild(5).GetComponent<Toggle>().isOn = options.KillPlayer;
                    transform.GetChild(0).GetChild(6).GetComponent<Dropdown>().value = (int)options.Color;
                    Panels[0].gameObject.SetActive(true);
                }
                else if (SelectionManager.Selection.CompareTag("BadBeanBarrier") || SelectionManager.Selection.tag == "PurpleBean")
                {
                    transform.GetChild(0).GetChild(3).GetComponent<Toggle>().isOn = options.NoClip;
                    Panels[1].gameObject.SetActive(true);
                }
                else if (SelectionManager.Selection.CompareTag("Player"))
                {
                    Panels[2].gameObject.SetActive(true);
                }
                else if (SelectionManager.Selection.CompareTag("Finish"))
                {
                    Panels[4].gameObject.SetActive(true);
                }
                else if (SelectionManager.Selection.CompareTag("Friend"))
                {
                    Panels[3].gameObject.SetActive(true);
                }
                else if (SelectionManager.Selection.CompareTag("Jump"))
                {
                    Panels[5].gameObject.SetActive(true);
                }                
                else if (SelectionManager.Selection.CompareTag("Enemy"))
                {
                    Panels[6].gameObject.SetActive(true);
                }
            }

        }

    }
    private void OnDisable()
    {
        foreach (var item in Panels)
        {
            item.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (MouseChecker.Holding() && ButtonHelding)
        {
            if (demintion == 1)
            {
                SelectionManager.Selection.position += (transform.right * (MovementSpeed / 2) * Time.deltaTime);
            }
            else if (demintion == 2)
            {
                SelectionManager.Selection.position += (transform.up * (MovementSpeed / 2) * Time.deltaTime);
            }
            else if (demintion == 3)
            {
                SelectionManager.Selection.position += (transform.forward * (MovementSpeed / 2) * Time.deltaTime);
            }
            else if (demintion == 4)
            {
                SelectionManager.Selection.position += (-transform.right * (MovementSpeed / 2) * Time.deltaTime);
            }
            else if (demintion == 5)
            {
                SelectionManager.Selection.position += (-transform.up * (MovementSpeed / 2) * Time.deltaTime);
            }
            else if (demintion == 6)
            {
                SelectionManager.Selection.position += (-transform.forward * (MovementSpeed / 2) * Time.deltaTime);
            }
            else if (demintion == 7)
            {
                SelectionManager.Selection.Rotate(transform.right * (MovementSpeed / 2) * Time.deltaTime * 2);
            }
            else if (demintion == 8)
            {
                SelectionManager.Selection.Rotate(transform.up * (MovementSpeed / 2) * Time.deltaTime * 2);
            }
            else if (demintion == 9)
            {
                SelectionManager.Selection.Rotate(transform.forward * (MovementSpeed / 2) * Time.deltaTime * 2);
            }
            else if (demintion == 10)
            {
                SelectionManager.Selection.Rotate(-transform.right * (MovementSpeed / 2) * Time.deltaTime * 2);
            }
            else if (demintion == 11)
            {
                SelectionManager.Selection.Rotate(-transform.up * (MovementSpeed / 2) * Time.deltaTime * 2);
            }
            else if (demintion == 12)
            {
                SelectionManager.Selection.Rotate(-transform.forward * (MovementSpeed / 2) * Time.deltaTime * 2);
            }
            else if (demintion == 13)
            {
                SelectionManager.Selection.localScale += (transform.right * MovementSpeed * Time.deltaTime);
            }
            else if (demintion == 14)
            {
                SelectionManager.Selection.localScale += (transform.up * MovementSpeed * Time.deltaTime);
            }
            else if (demintion == 15)
            {
                SelectionManager.Selection.localScale += (transform.forward * MovementSpeed * Time.deltaTime);
            }
            else if (demintion == 16)
            {
                SelectionManager.Selection.localScale += (-transform.right * MovementSpeed * Time.deltaTime);
            }
            else if (demintion == 17)
            {
                SelectionManager.Selection.localScale += (-transform.up * MovementSpeed * Time.deltaTime);
            }
            else if (demintion == 18)
            {
                SelectionManager.Selection.localScale += (-transform.forward * MovementSpeed * Time.deltaTime);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ButtonHelding = false;
        }
    }

    public void NoClip(bool value)
    {
        SelectionManager.Selection.GetComponent<ObjectsOptions>().NoClip = value;
    }
    public void Invisible(bool value)
    {
        SelectionManager.Selection.GetComponent<ObjectsOptions>().Invisible = value;
    }
    public void KillPlayer(bool value)
    {
        SelectionManager.Selection.GetComponent<ObjectsOptions>().KillPlayer = value;
    }
    public void ObjectColors(Int32 value)
    {
        SelectionManager.DefaultMaterial = ObjectMaterials[value];
        SelectionManager.Selection.GetComponent<ObjectsOptions>().Color = (ObjectsOptions.ObjectColors)value;
    }

    public void PositionPlusNumberX()
    {
        demintion = 1;
        ButtonHelding = true;
        SelectionManager.Selection.position += (transform.right * MovementSpeed * Time.deltaTime);
    }
    public void PositionPlusNumberY()
    {
        demintion = 2;
        ButtonHelding = true;
        SelectionManager.Selection.position += (transform.up * MovementSpeed * Time.deltaTime);
    }
    public void PositionPlusNumberZ()
    {
        demintion = 3;
        ButtonHelding = true;
        SelectionManager.Selection.position += (transform.forward * MovementSpeed * Time.deltaTime);
    }
    public void PositionMinusNumberX()
    {
        demintion = 4;
        ButtonHelding = true;
        SelectionManager.Selection.position += (-transform.right * MovementSpeed * Time.deltaTime);
    }
    public void PositionMinusNumberY()
    {
        demintion = 5;
        ButtonHelding = true;
        SelectionManager.Selection.position += (-transform.up * MovementSpeed * Time.deltaTime);
    }
    public void PositionMinusNumberZ()
    {
        demintion = 6;
        ButtonHelding = true;
        SelectionManager.Selection.position += (-transform.forward * MovementSpeed * Time.deltaTime);
    }
    public void RotationPlusNumberX()
    {
        demintion = 7;
        ButtonHelding = true;
        SelectionManager.Selection.Rotate(transform.right * MovementSpeed * Time.deltaTime);
    }
    public void RotationPlusNumberY()
    {
        demintion = 8;
        ButtonHelding = true;
        SelectionManager.Selection.Rotate(transform.up * MovementSpeed * Time.deltaTime);
    }
    public void RotationPlusNumberZ()
    {
        demintion = 9;
        ButtonHelding = true;
        SelectionManager.Selection.Rotate(transform.forward * MovementSpeed * Time.deltaTime);
    }
    public void RotationMinusNumberX()
    {
        demintion = 10;
        ButtonHelding = true;
        SelectionManager.Selection.Rotate(-transform.right * MovementSpeed * Time.deltaTime);
    }
    public void RotationMinusNumberY()
    {
        demintion = 11;
        ButtonHelding = true;
        SelectionManager.Selection.Rotate(-transform.up * MovementSpeed * Time.deltaTime);
    }
    public void RotationMinusNumberZ()
    {
        demintion = 12;
        ButtonHelding = true;
        SelectionManager.Selection.Rotate(-transform.forward * MovementSpeed * Time.deltaTime);
    }
    public void ScalePlusNumberX()
    {
        demintion = 13;
        ButtonHelding = true;
        SelectionManager.Selection.localScale += (transform.right * MovementSpeed * Time.deltaTime);
    }
    public void ScalePlusNumberY()
    {
        demintion = 14;
        ButtonHelding = true;
        SelectionManager.Selection.localScale += (transform.up * MovementSpeed * Time.deltaTime);
    }
    public void ScalePlusNumberZ()
    {
        demintion = 15;
        ButtonHelding = true;
        SelectionManager.Selection.localScale += (transform.forward * MovementSpeed * Time.deltaTime);
    }
    public void ScaleMinusNumberX()
    {
        demintion = 16;
        ButtonHelding = true;
        SelectionManager.Selection.localScale += (-transform.right * MovementSpeed * Time.deltaTime);
    }
    public void ScaleMinusNumberY()
    {
        demintion = 17;
        ButtonHelding = true;
        SelectionManager.Selection.localScale += (-transform.up * MovementSpeed * Time.deltaTime);
    }
    public void ScaleMinusNumberZ()
    {
        demintion = 18;
        ButtonHelding = true;
        SelectionManager.Selection.localScale += (-transform.forward * MovementSpeed * Time.deltaTime);
    }
}
