using UnityEngine;

namespace WinterUniverse
{
    public class RandomObjectActivator : MonoBehaviour
    {
        [SerializeField] private GameObject[] _objects;

        private void OnEnable()
        {
            foreach (GameObject go in _objects)
            {
                go.SetActive(false);
            }
            _objects[Random.Range(0, _objects.Length)].SetActive(true);
        }
    }
}