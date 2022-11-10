using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{

    [SerializeField] private Text logText;

    void Start()
    {
        PhotonNetwork.NickName = "Player" + Random.Range(0, 10000);
        Log("Name player: " + PhotonNetwork.NickName);

        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Log("Connect to master");
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Log("Joined in room");

        PhotonNetwork.LoadLevel("MainScene");
    }

    private void Log(string message)
    {
        Debug.Log(message);
        logText.text += "\n";
        logText.text += message;
    }
}
