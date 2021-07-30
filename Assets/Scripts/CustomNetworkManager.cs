using Mirror;
using UnityEngine;

public class CustomNetworkManager : NetworkManager {
    public override void OnServerAddPlayer(NetworkConnection conn) {
        base.OnServerAddPlayer(conn);

        NetworkPlayer player = conn.identity.GetComponent<NetworkPlayer>();
        player.SetDisplayName($"Player {numPlayers}");
        player.SetDisplayColor();
    }
}
