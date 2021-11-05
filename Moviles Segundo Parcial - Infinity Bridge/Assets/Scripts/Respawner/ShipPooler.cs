using System.Collections.Generic;
using UnityEngine;

public class ShipPooler : MonoBehaviourSingleton<ShipPooler>
{
    [Header("Ships Spawner")]
    [SerializeField] private Transform shipSpawner;
    [SerializeField] private float timeToStart = 10f;
    [SerializeField] private float minTimeToRespawnShip = 5f;
    [SerializeField] private float maxTimeToRespawnShip = 7f;
    [SerializeField] private float timeToRespawnShip = 0f;

    [Header("Dangerous Ship")]
    [SerializeField] int numberOfShipPieces = 10;
    private GameObject prefShip;

    // =============================

    private Queue<GameObject> shipQueue;
    private float timeShip = 0f;
    private bool start = false;

    private enum SpawnerState
    {
        Initializing,
        Updating,
        Stop
    };
    private SpawnerState spawnerState = SpawnerState.Initializing;

    // =============================

    public override void Awake()
    {
        base.Awake();

        Object prefS = Resources.Load("Bridge/Dangerous_Ship", typeof(GameObject));
        prefShip = (GameObject)prefS;

        shipQueue = new Queue<GameObject>();

        for (int i = 0; i < numberOfShipPieces; i++)
        {
            GameObject go = Instantiate(prefShip);
            go.transform.parent = this.transform;

            go.transform.name = prefShip.name + "_" + i;

            go.SetActive(false);

            shipQueue.Enqueue(go);
        }

        timeToRespawnShip = Random.Range(minTimeToRespawnShip, maxTimeToRespawnShip);
    }

    private void OnEnable()
    {
        PlayerState.LoseGame += StopShipPooler;
    }

    private void OnDisable()
    {
        PlayerState.LoseGame -= StopShipPooler;
    }

    private void Update()
    {
        if (spawnerState != SpawnerState.Stop)
        {
            timeShip += Time.deltaTime;

            if (start == false)
            {
                if (timeShip > timeToStart)
                {
                    start = true;
                    timeShip = 0f;
                }
            }
            else if (timeShip >= timeToRespawnShip)
            {
                RespawnShip();

                timeToRespawnShip = Random.Range(minTimeToRespawnShip, maxTimeToRespawnShip);

                timeShip = 0f;
            }
        }
    }

    // =============================

    //public Queue<GameObject> GetBridgeList()
    //{
    //    return bridgeQueue;
    //}
    //
    //public void ActivateBridgePiece()
    //{
    //    bridgeQueue.Peek().SetActive(true);
    //}
    //
    //public void DesactivateBridgePiece()
    //{
    //    bridgeQueue.Peek().SetActive(false);
    //}

    // =============================

    public void RespawnShip()
    {
        GameObject piece;
        piece = shipQueue.Dequeue();
        
        float rand = Random.Range(-shipSpawner.localScale.x / 2, shipSpawner.localScale.x / 2);
        Vector3 newPos = new Vector3(shipSpawner.position.x, shipSpawner.position.y, rand);
        
        piece.transform.position = newPos;
        
        switch (spawnerState)
        {
            case SpawnerState.Initializing:
        
                piece.SetActive(true);
                shipQueue.Enqueue(piece);
        
                break;
        
            case SpawnerState.Updating:

                shipQueue.Enqueue(piece);
        
                break;
        }
    }

    public void StopShipPooler()
    {
        spawnerState = SpawnerState.Stop;
    }
}
