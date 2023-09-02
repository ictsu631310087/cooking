using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Not2Rhythm : MonoBehaviour
{
    [SerializeField] private GameObject[] arrow = new GameObject[4]; //^ v < >
    [SerializeField] private GameObject displayPsition;
    public List<int> intAllArrow;
    public List<int> intArrow;
    public List<GameObject> arrowShowObj;
    public int difficulty = -1;//3-0
    public bool haveRhythm = false;
    public int deHeat = 0;
    private int buttonPressed = 0;
    public void ShowRhythmArrow(List<int> x)
    {
        GameObject _Arrow;
        for (int i = 0; i < x.Count; i++)
        {
            _Arrow = Instantiate(arrow[intArrow[i]], displayPsition.transform, false);
            arrowShowObj.Add(_Arrow);
        }
    }
    private void checkArrow(int i)
    {
        if (intArrow[0] == i)
        {
            arrowShowObj[buttonPressed].GetComponent<RawImage>().color = new Color32(255, 255, 0, 255);
            deHeat = 5;
            buttonPressed++;
        }
        else
        {
            arrowShowObj[buttonPressed].GetComponent<RawImage>().color = new Color32(255, 0, 0, 255);
            deHeat = -20;
            buttonPressed++;
        }
        if (buttonPressed >= 4)
        {
            for (int j = 0; j < arrowShowObj.Count; j++)
            {
                Destroy(arrowShowObj[j], 0);
            }
            arrowShowObj.Clear();
            buttonPressed = 0;
        }
        intArrow.RemoveAt(0);        
    }
    public void ClearRhythm()
    {
        intAllArrow.Clear();
        intArrow.Clear();
        for (int i = 0; i < arrowShowObj.Count; i++)
        {
            Destroy(arrowShowObj[i], 0);
        }
        arrowShowObj.Clear();
        difficulty = -1;
        //haveRhythm = false;
    }
    private void Update()
    {
        //Debug.Log(haveRhythm);
        if (!haveRhythm)
        {
            switch (difficulty)
            {
                case 1:
                    for (int i = 0; i < 4; i++)
                    {
                        intArrow.Add(intAllArrow[i]);
                    }
                    break;
                case 2:
                    for (int i = 4; i < 8; i++)
                    {
                        intArrow.Add(intAllArrow[i]);
                    }
                    break;
                case 3:
                    for (int i = 8; i < 12; i++)
                    {
                        intArrow.Add(intAllArrow[i]);
                    }
                    break;
                default:
                    break;
            }
            ShowRhythmArrow(intArrow);
            haveRhythm = true;
        }
        if (intArrow.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                checkArrow(0);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                checkArrow(1);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                checkArrow(2);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                checkArrow(3);
            }
        }
        else if (intArrow.Count == 0 && haveRhythm)
        {
            haveRhythm = false;
            difficulty--;
        }
        //Debug.Log("difficulty : " + difficulty);
    }
}
