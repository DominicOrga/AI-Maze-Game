using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAnimator : MonoBehaviour {

    public GameObject uiGoPrefab;
    public GameObject uiOnePrefab;
    public GameObject uiTwoPrefab;
    public GameObject uiThreePrefab;
    public GameObject uiBlobWinsPrefab;
    public GameObject uiBlipWinsPrefab;
    public GameObject homeButton;

    Transform cameraTransform;
    LevelManager levelManager;
    Transform blockTransform;

    bool isMoveCamera;
    float cameraSpeed = 25f;

    void Awake() {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        blockTransform = GameObject.FindGameObjectWithTag("Block").GetComponent<Transform>();
    }

    // Use this for initialization
    

	// Use this for initialization
	void Start () {
    }

    void Update() {
        if (isMoveCamera) {
            float step = cameraSpeed * Time.deltaTime;
            Vector3 newPosition = Vector3.MoveTowards(cameraTransform.position, blockTransform.position, step);
            newPosition.z = -10;

            cameraTransform.position = newPosition;

            float deltaX = Mathf.Abs(cameraTransform.position.x - blockTransform.position.x);
            float deltaY = Mathf.Abs(cameraTransform.position.y - blockTransform.position.y);


            if (deltaX < 1 && deltaY < 1) {
                isMoveCamera = false;
            }
        }
    }

    public void PlayStartGame(int startNodeIdx) {
        StartCoroutine(StartGame(startNodeIdx));
    }

    IEnumerator StartGame(int startNodeIdx) {

        yield return new WaitForSeconds(1f);

        GameObject obj = Instantiate(uiThreePrefab, new Vector3(cameraTransform.position.x, cameraTransform.position.y, 10), new Quaternion(0,0,0,0));
        yield return new WaitForSeconds(1f);
        Destroy(obj);

        obj = Instantiate(uiTwoPrefab, new Vector3(cameraTransform.position.x, cameraTransform.position.y, 10), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(1f);
        Destroy(obj);

        obj = Instantiate(uiOnePrefab, new Vector3(cameraTransform.position.x, cameraTransform.position.y, 10), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(1f);
        Destroy(obj);

        obj = Instantiate(uiGoPrefab, new Vector3(cameraTransform.position.x, cameraTransform.position.y, 10), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(1f);
        Destroy(obj);

        levelManager.startGame(startNodeIdx);
    }

    WaitUntil MoveCameraToBlock() {
        isMoveCamera = true;
        return new WaitUntil(() => !isMoveCamera);
    }

    public void StartEndGame(bool isBlipWon) {
        StartCoroutine(EndGame(isBlipWon));
    }

	IEnumerator EndGame(bool isBlipWon) {
        cameraTransform.parent = null;
        yield return MoveCameraToBlock();

        Instantiate(isBlipWon ? uiBlipWinsPrefab : uiBlobWinsPrefab, new Vector3(cameraTransform.position.x, cameraTransform.position.y, 10), new Quaternion(0, 0, 0, 0));
        homeButton.SetActive(true);
        yield break;
    }
}
