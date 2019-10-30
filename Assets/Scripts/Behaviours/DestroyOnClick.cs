using UnityEngine;

internal class DestroyOnClick : IClickBehaviour
{
    private GameObject _gameObject;

    public DestroyOnClick(GameObject gameObject)
    {
        _gameObject = gameObject;
    }

    public void Click()
    {
        Object.Destroy(_gameObject);
    }
}