using Zenject;

internal class LoseOnClick : IClickBehaviour
{
    GameManager _gameManager;
    public void Click()
    {
        _gameManager.GameOver();
    }
}