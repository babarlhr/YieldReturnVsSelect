public class ConferenceSession
{
    public string ConferenceName { get; set; }

    public static List<ConferenceSession> Create()
    {
        var sessions = new List<ConferenceSession>();
        for (int i = 0; i < 100; i++)
        {
            sessions.Add(new ConferenceSession {ConferenceName = $"Conference {i}"});
        }

        return sessions;
    }
}