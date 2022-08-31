using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class YieldReturnVsSelectBenchmark
{
    private List<ConferenceSession> _sessions = ConferenceSession.Create();
    private readonly Consumer _consumer = new Consumer();

    [Benchmark]
    public void CallYield()
    {
        YieldReturn().Consume(_consumer);
    }

    private IEnumerable<string> YieldReturn()
    {
        foreach (var session in _sessions)
        {
            yield return session.ConferenceName;
        }
    }

    [Benchmark]
    public void CallWithList()
    {
        ListReturn().Consume(_consumer);
    }

    private IEnumerable<string> ListReturn()
    {
        List<string> sessionNames = new();
        foreach(var session in _sessions)
        {
            sessionNames.Add(session.ConferenceName);    
        }

        return sessionNames;
    }

    [Benchmark]
    public void CallSelect()
    {
        SelectReturn().Consume(_consumer);
    }

    private IEnumerable<string> SelectReturn()
    {
        return _sessions.Select(c => c.ConferenceName);
    }
}