public class NotificationLink
{
    private GameState _state;
    private NotificationLink _successor;
    private string _message;

    public NotificationLink(GameState state, string message)
    {
        _state = state;
        _message = message;
    }

    public void SetSuccessor(NotificationLink successor)
    {
        _successor = successor;
    }

    public string GetNotification(GameState state)
    {
        if (_state == state) {
            return _message;
        }
        else {
            return _successor.GetNotification(state);
        }
    }
}