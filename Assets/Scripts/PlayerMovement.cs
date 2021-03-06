using Mirror;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : NetworkBehaviour {
    [SerializeField] private NavMeshAgent agent = null;

    private Camera _mainCamera;


    #region Server

    [Command]
    private void CmdMove(Vector3 position) {
        if (NavMesh.SamplePosition(position, out NavMeshHit hit, 1f, NavMesh.AllAreas)) {
            agent.SetDestination(hit.position);
        }
    }

    #endregion

    #region Client

    public override void OnStartAuthority() {
        _mainCamera = Camera.main;
    }

    [ClientCallback]
    private void Update() {
        if (hasAuthority) {
            if (Input.GetMouseButtonDown(1)) {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) {
                    CmdMove(hit.point);
                }
            }
        }
    }

    #endregion
}
