using NBench;
using ProjectManagerApi.Controllers;
using ProjectManagerApi.Entities.EntityModels;
using System.Net.Http;
using System.Web.Http;

namespace ProjectManagerApi.Tests
{
    public class PerformanceTests
    {
        private Counter _counter;
        public const string counterName = "PerfCounter";
        private TaskController _controller = new TaskController()
        {
            Request = new HttpRequestMessage(),
            Configuration = new HttpConfiguration()
        };
        private TaskModel task = null;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _counter = context.GetCounter(counterName);
        }

        
        [PerfBenchmark(Description = "Test get task performance.",
            NumberOfIterations = 200, RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 6000, TestMode = TestMode.Measurement, SkipWarmups = false)]
        [CounterMeasurement(counterName)]
            [CounterThroughputAssertion(counterName,MustBe.GreaterThan,100)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]
        public void Get_TaskTest()
        {
            var result = _controller.GetTasks();
            _counter.Increment();
        }

        [PerfBenchmark(Description = "Test get parent task performance.",
            NumberOfIterations = 200, RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 6000, TestMode = TestMode.Measurement, SkipWarmups = false)]
        [CounterMeasurement(counterName)]
            [CounterThroughputAssertion(counterName, MustBe.GreaterThan, 100)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]
        public void Get_ParentTaskTest()
        {
            var result = _controller.GetParentTasks();
            _counter.Increment();
        }


        [PerfCleanup]
        public void Cleanup()
        {
            // does nothing
        }
    }
}
