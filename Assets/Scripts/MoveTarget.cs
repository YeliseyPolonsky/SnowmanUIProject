using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update() => transform.position = _target.position;
}
