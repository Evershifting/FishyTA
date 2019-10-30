internal class LoseOnPassLine : IPassLineBehaviour
{
    GameManager _gameManager;
    public void PassLine()
    {
        _gameManager.LoseLife();
    }
}