using System.Collections;
using System.Collections.Generic;
using Application_Manager;
using Application_Manager.States;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    [SerializeField] private GameObject fireBall;
    [SerializeField] private Vector2 startPos;
    [SerializeField] private int objectPoolLimit = 5;
    [SerializeField] private float spawnTimeInSeconds = 3f;

    [Header("Game States")]
    [SerializeField] private BaseState playingState;
    

    private Queue<GameObject> m_fireBallPool;
    private bool m_canInstantiate = true;

    private void Start() {
        m_fireBallPool = new Queue<GameObject>();
        StartCoroutine(spawning());
    }
    
    // TODO: Update this methods to improved game manager
    private IEnumerator spawning() {
        while (ApplicationManager.Instance.GetCurrentState() == playingState) {
            yield return new WaitForSeconds(spawnTimeInSeconds);
            if (m_canInstantiate) {
                m_fireBallPool.Enqueue(Instantiate(fireBall, startPos, Quaternion.identity));
                if (m_fireBallPool.Count > objectPoolLimit) {
                    m_canInstantiate = false;
                }
            }
            else {
                GameObject tempGo = m_fireBallPool.Dequeue();
                tempGo.transform.position = startPos;
                tempGo.SetActive(true);
                tempGo.GetComponent<EnemyBehaviour>().resetDirection();
                m_fireBallPool.Enqueue(tempGo);
            }
        }
    }
}