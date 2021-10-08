using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePooler : MonoBehaviourSingleton<BridgePooler>
{
    [Header("Spawner")]
    [SerializeField] Transform spawner;
    [SerializeField] float minTimeToRespawn = 5f;
    [SerializeField] float maxTimeToRespawn = 7f;
    [SerializeField] private float timeToRespawn = 0f;


    [Header("Bridge")]
    [SerializeField] GameObject prefBridge;
    [SerializeField] int numberOfBridgePieces = 15;

    private Queue<GameObject> bridgeQueue;
    private float time = 0f;

    private enum SpawnerState
    {
        Initializing,
        Updating
    };
    private SpawnerState spawnerState = SpawnerState.Initializing;

    // =============================

    public override void Awake()
    {
        base.Awake();

        bridgeQueue = new Queue<GameObject>();

        for (int i = 0; i < numberOfBridgePieces; i++)
        {
            GameObject go = Instantiate(prefBridge);
            go.transform.parent = this.transform;

            go.SetActive(false);

            bridgeQueue.Enqueue(go);
        }

        timeToRespawn = Random.Range(minTimeToRespawn, maxTimeToRespawn);
    }

    private void Update()
    {
        time += Time.deltaTime;

        if(time >= timeToRespawn)
        {
            RespawnPiece();

            timeToRespawn = Random.Range(minTimeToRespawn, maxTimeToRespawn);

            time = 0f;
        }
    }

    // =============================

    public Queue<GameObject> GetBridgeList()
    {
        return bridgeQueue;
    }

    public void ActivateBridgePiece()
    {
        bridgeQueue.Peek().SetActive(true);
    }
    
    public void DesactivateBridgePiece()
    {
        bridgeQueue.Peek().SetActive(false);
    }

    // =============================

    public void RespawnPiece()
    {
        GameObject piece;
        piece = bridgeQueue.Dequeue();
        piece.transform.position = spawner.position;

        switch (spawnerState)
        {
            case SpawnerState.Initializing:
                
                piece.SetActive(true);
                bridgeQueue.Enqueue(piece);

                break;

            case SpawnerState.Updating:

                bridgeQueue.Enqueue(piece);
                
                break;
        }
    }

}
