using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    // Start is called before the first frame update
    public ElVector3 lastPlayerPosition;
    public Transform playerTransform;
    private void Start()
    {
        playerTransform.position = lastPlayerPosition.valor;
    }
}
