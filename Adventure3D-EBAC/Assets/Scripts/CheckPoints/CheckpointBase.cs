using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckpointBase : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public int key = 01;
    public TMP_Text checkpointMessage;

    private bool checkpointActived = false;
    private string checkpointKey = "CheckpointKey";
        
    private void OnTriggerEnter(Collider other)
    {
        if (!checkpointActived && other.transform.tag == "Player")
        CheckCheckPoint();
    }

    private void CheckCheckPoint()
    {
        TurnItOn();
        SaveCheckPoint();
    }

    [NaughtyAttributes.Button]
    private void TurnItOn()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.white);

    }

    private void TurnItOff()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.grey);
    }

    private void SaveCheckPoint()
    {
        /*if(PlayerPrefs.GetInt(checkpointKey, 0) > key)
            PlayerPrefs.SetInt(checkpointKey, key);*/

        CheckpointManager.Instance.SaveCheckPoint(key);

        checkpointActived = true;
        CheckpointActive();
    }

    public void CheckpointActive()
    {
        checkpointMessage.text = "Checkpoint ativo";
        StartCoroutine(ClearMessage());
    }

    private IEnumerator ClearMessage()
    {
        yield return new WaitForSeconds(2);
        checkpointMessage.text = "";
    }
}
