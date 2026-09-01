using System;

namespace Question1_WorkflowEngine
{
    public class Request
    {
        public int RequestId { get; set; }
        public string RequestedBy { get; set; } = string.Empty;
        public int Amount { get; set; }
        public int Experience { get; set; }
        public int Priority { get; set; }
    }

    public delegate string WorkflowProcessor(Request request);

    public class HRWorkflowRules
    {
        public string ProcessHR(Request request)
        {
            return request.Experience >= 5 ? "Approved" : "Rejected";
        }
    }

    public class FinanceWorkflowRules
    {
        public string ProcessFinance(Request request)
        {
            return request.Amount <= 50000 ? "Approved" : "Rejected";
        }
    }

    public class ITWorkflowRules
    {
        public string ProcessIT(Request request)
        {
            return request.Priority >= 7 ? "Approved" : "Rejected";
        }
    }

    public class WorkflowEngine
    {
        public void Process(Request request, string workflowType, WorkflowProcessor processor)
        {
            string decision = processor(request);
            Console.WriteLine("========= WORKFLOW PROCESSING =========");
            Console.WriteLine($"Request By   : {request.RequestedBy}");
            Console.WriteLine($"Workflow     : {workflowType}");
            Console.WriteLine($"Decision     : {decision}");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Request request = new Request
            {
                RequestId = 501,
                RequestedBy = "Rohan",
                Amount = 40000,
                Experience = 6,
                Priority = 8
            };

            HRWorkflowRules hrRules = new HRWorkflowRules();
            FinanceWorkflowRules financeRules = new FinanceWorkflowRules();
            ITWorkflowRules itRules = new ITWorkflowRules();

            WorkflowEngine engine = new WorkflowEngine();

            engine.Process(request, "HR", hrRules.ProcessHR);
            engine.Process(request, "Finance", financeRules.ProcessFinance);
            engine.Process(request, "IT", itRules.ProcessIT);
        }
    }
}
