using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MultiplayerManager : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject playerPrefab;

    [SerializeField] private GameObject mainCamera;

    void Start()
    {
        Vector3 pos = new Vector3(Random.Range(3f, -3f), 0, 1);
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, pos, Quaternion.identity);

        CameraFollow cameraFollow = mainCamera.GetComponent<CameraFollow>();
        cameraFollow.SetTarget(player.transform);
    }

    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player {0} entered room" + newPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Player {0} left room" + otherPlayer.NickName);
    }

}
