using BenchmarkDotNet.Running;

// Let's test this comment out:
// https://www.linkedin.com/feed/update/urn:li:activity:6970321908567298048?commentUrn=urn%3Ali%3Acomment%3A%28activity%3A6970321908567298048%2C6970639326904762368%29
BenchmarkRunner.Run<YieldReturnVsSelectBenchmark>();