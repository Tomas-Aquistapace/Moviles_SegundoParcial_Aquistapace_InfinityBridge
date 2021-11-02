using System.Collections.Generic;
using UnityEngine;

public class BridgePooler : MonoBehaviourSingleton<BridgePooler>
{
    [Header("Bridge Spawner")]
    [SerializeField] private Transform bridgeSpawner;
    [SerializeField] private float minTimeToRespawnBridge = 5f;
    [SerializeField] private float maxTimeToRespawnBridge = 7f;
    [SerializeField] private float timeToRespawnBridge = 0f;

    [Header("Bridge")]
    [SerializeField] int numberOfBridgePieces = 15;
    private GameObject prefBridge;

    [Header("Coin")]
    [SerializeField] private int numberOfCoins = 5;
    [SerializeField] private int min_distanceBetweenCoins = 5;
    [SerializeField] private int max_distanceBetweenCoins = 9;
    [SerializeField] private int distanceBetweenCoins = 0;
    private GameObject prefCoin;

    // =============================

    private Queue<GameObject> bridgeQueue;
    private float timeBridge = 0f;
    
    private Queue<GameObject> coinsQueue;
    private int coinIndex = 0;

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

        // Bridge:

        Object pref = Resources.Load("Bridge/Piece_of_Bridge", typeof(GameObject));
        prefBridge = (GameObject)pref;

        bridgeQueue = new Queue<GameObject>();

        for (int i = 0; i < numberOfBridgePieces; i++)
        {
            GameObject go = Instantiate(prefBridge);
            go.transform.parent = this.transform;

            go.transform.name = prefBridge.name + "_" + i;

            go.SetActive(false);

            bridgeQueue.Enqueue(go);
        }

        timeToRespawnBridge = Random.Range(minTimeToRespawnBridge, maxTimeToRespawnBridge);

        // Coin:

        coinsQueue = new Queue<GameObject>();

        Object coin = Resources.Load("Coin/Coin_Collectible", typeof(GameObject));
        prefCoin = (GameObject)coin;

        for (int i = 0; i < numberOfCoins; i++)
        {
            GameObject c = Instantiate(prefCoin);
            c.transform.parent = this.transform;

            c.transform.name = prefCoin.name + "_" + i;

            c.SetActive(false);

            coinsQueue.Enqueue(c);
        }

        distanceBetweenCoins = Random.Range(min_distanceBetweenCoins, max_distanceBetweenCoins);
    }

    private void OnEnable()
    {
        PlayerState.LoseGame += StopBridgePooler;
    }

    private void OnDisable()
    {
        PlayerState.LoseGame -= StopBridgePooler;        
    }

    private void Update()
    {
        if(spawnerState != SpawnerState.Stop)
        {
            timeBridge += Time.deltaTime;

            if(timeBridge >= timeToRespawnBridge)
            {
                RespawnPiece();

                timeToRespawnBridge = Random.Range(minTimeToRespawnBridge, maxTimeToRespawnBridge);

                timeBridge = 0f;
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

    public void RespawnPiece()
    {
        GameObject piece;
        piece = bridgeQueue.Dequeue();

        float rand = Random.Range(-bridgeSpawner.localScale.x / 2, bridgeSpawner.localScale.x / 2);
        Vector3 newPos = new Vector3(rand, bridgeSpawner.position.y, bridgeSpawner.position.z);

        piece.transform.GetComponent<PieceController>().ResetState(newPos);

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

        // ---

        SpawnACoin(piece);
    }

    void SpawnACoin(GameObject piece)
    {
        coinIndex++;

        if(coinIndex >= distanceBetweenCoins)
        {
            coinIndex = 0;
            distanceBetweenCoins = Random.Range(min_distanceBetweenCoins, max_distanceBetweenCoins);


            GameObject c;
            c = coinsQueue.Dequeue();

            c.SetActive(true);

            coinsQueue.Enqueue(c);

            c.transform.parent = piece.GetComponentInChildren<Transform>();
            c.transform.position = piece.GetComponentInChildren<Transform>().position + new Vector3(0, c.transform.position.y, 0);
        }
    }

    // ================================
    
    public void StopBridgePooler()
    {
        spawnerState = SpawnerState.Stop;
    }
}
