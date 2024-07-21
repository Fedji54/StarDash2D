using UnityEngine;

namespace WinterUniverse
{
    public abstract class ObstacleBehaviour : MonoBehaviour
    {
        [SerializeField] protected Transform _affectedObject;
    }
}