using UnityEngine;

public class MyCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out Enemy enemy)) {
            enemy.Attack();
        }
    }
}