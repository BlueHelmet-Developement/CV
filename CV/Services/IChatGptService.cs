namespace CV.Services
{
    public interface IChatGptService
    {
        Task<string> GetChatGPTResponseAsync(string prompt);
    }
}
