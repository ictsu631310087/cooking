using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTableScript : MonoBehaviour
{
    public int idTable;
    public GameObject glowObject;
    public bool checkObjedBool = false;
    public GameObject checkObject;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            glowObject.SetActive(true);
            InteractionPlayerScript.priorityInteraction.Add(idTable);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            glowObject.SetActive(false);
            InteractionPlayerScript.priorityInteraction.Remove(idTable);
        }
    }

    private void Start()
    {
        glowObject.SetActive(false);
        checkObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (InteractionPlayerScript.priorityInteraction.Count > 0)
        {
            if (InteractionPlayerScript.priorityInteraction[InteractionPlayerScript.priorityInteraction.Count - 1] == idTable)
            {
                glowObject.SetActive(true);
                if ((Input.GetKeyUp(KeyCode.Q) || Input.GetButtonUp("Jump")) && !checkObjedBool)
                {
                    checkObject.SetActive(true);
                    checkObjedBool = true;
                }
                else if ((Input.GetKeyUp(KeyCode.Q) || Input.GetButtonUp("Jump")) && checkObjedBool)
                {
                    checkObject.SetActive(false);
                    checkObjedBool = false;
                }
            }
            else if (InteractionPlayerScript.priorityInteraction[InteractionPlayerScript.priorityInteraction.Count - 1] != idTable)
            {
                glowObject.SetActive(false);
            }
        }
    }
}
