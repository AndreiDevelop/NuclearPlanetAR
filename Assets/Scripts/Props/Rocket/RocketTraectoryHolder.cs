using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTraectoryHolder : MonoBehaviour
{
    public Transform[] controllPoint;

    [SerializeField] private float _gizmoSphereDiametr = 0.25f;
    [SerializeField] private Color _gizmoSphereColor;

    private List<Vector3> _rocketPositionsList = new List<Vector3>();
    public List<Vector3> RocketPositionsList => _rocketPositionsList;

    private void OnDrawGizmos()
    {
        CalculateRocketPositions();
        DrawPositions();
    }

    public void CalculateRocketPositions()
    {
        for (float t = 0; t <= 1; t += 0.05f)
        {
            Vector3 rocketPositions = Mathf.Pow(1 - t, 3) * controllPoint[0].position +
                3 * Mathf.Pow(1 - t, 2) * t * controllPoint[1].position +
                3 * (1 - t) * Mathf.Pow(t, 2) * controllPoint[2].position +
                Mathf.Pow(t, 3) * controllPoint[3].position;

            _rocketPositionsList.Add(rocketPositions);
        }
    }

    public void DrawPositions()
    {
        Gizmos.color = _gizmoSphereColor;

        foreach (Vector3 bufPosition in _rocketPositionsList)
            Gizmos.DrawSphere(bufPosition, _gizmoSphereDiametr);

        Gizmos.color = Color.white;

        Gizmos.DrawLine(controllPoint[0].position, controllPoint[1].position);
        Gizmos.DrawLine(controllPoint[2].position, controllPoint[3].position);
    }
}
