using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwaitAsync
{
    public partial class Desktop : Form
    {
        public Desktop()
        {
            InitializeComponent();
        }

        public static string GetThreadId()
        {
            return Thread.CurrentThread.ManagedThreadId.ToString("000");
        }

        public static void TaskRun()
        {
            Console.WriteLine($"======== ThreadId:{GetThreadId()} Start.");
            Thread.Sleep(3000);
            Console.WriteLine($"======== ThreadId:{GetThreadId()} End.");
        }

        #region async/await

        private void btnAsync_Click(object sender, EventArgs e)
        {
            Task task = NoReturnTask();
        }

        private async Task NoReturnTask()
        {
            Console.WriteLine($"==== ThreadId:{GetThreadId()} Start.");
            await Task.Run(() => TaskRun());
            Console.WriteLine($"==== ThreadId:{GetThreadId()} End.");
        }

        #endregion async/await

        #region async/await 2

        private void btnAsync2_Click(object sender, EventArgs e)
        {
            var stateMachine = new AsyncStateMachine();
            stateMachine.builder = AsyncTaskMethodBuilder.Create();
            stateMachine.state = -1;
            stateMachine.builder.Start(ref stateMachine);
            Task task = stateMachine.builder.Task;
        }

        private class AsyncStateMachine : IAsyncStateMachine
        {
            public int state;
            public AsyncTaskMethodBuilder builder;
            private TaskAwaiter taskAwaiter;

            public void MoveNext()
            {
                int num = state;
                try
                {
                    TaskAwaiter awaiter;
                    if (num != 0)
                    {
                        Console.WriteLine("==== ThreadId:" + GetThreadId() + " Start.");
                        awaiter = Task.Run(() => TaskRun()).GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            num = state = 0;
                            taskAwaiter = awaiter;
                            AsyncStateMachine stateMachine = this;
                            builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
                            return;
                        }
                    }
                    else
                    {
                        awaiter = taskAwaiter;
                        taskAwaiter = default;
                        num = state = -1;
                    }
                    awaiter.GetResult();
                    Console.WriteLine($"==== ThreadId:{GetThreadId()} End.");
                }
                catch (Exception ex)
                {
                    state = -2;
                    builder.SetException(ex);
                    return;
                }

                state = -2;
                builder.SetResult();
            }

            void IAsyncStateMachine.MoveNext()
            {
                MoveNext();
            }

            public void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }

            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
                SetStateMachine(stateMachine);
            }
        }

        #endregion async/await 2
    }
}