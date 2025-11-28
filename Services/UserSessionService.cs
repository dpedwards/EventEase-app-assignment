namespace EventEase.Services
{
    public class UserSessionService
    {
        public string UserName { get; private set; } = string.Empty;
        public bool IsLoggedIn => !string.IsNullOrEmpty(UserName);

        public event Action? OnChange;

        public void Login(string userName)
        {
            UserName = userName;
            NotifyStateChanged();
        }

        public void Logout()
        {
            UserName = string.Empty;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
