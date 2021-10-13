using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Igtampe.ImageToBasicGraphic {
    
    /// <summary>Handles async thread drawing operations</summary>
    public class DrawThread {

        /// <summary>Collection of tasks that need to be executed</summary>
        private ConcurrentQueue<Task> Tasks;

        /// <summary>Handle that's set when the drawthread should actually *do* something</summary>
        private AutoResetEvent Handle;

        /// <summary>Whether or not a cancellation is pending</summary>
        private bool CancelationPending = false;

        /// <summary>Inner task handling the execution of the given tasks</summary>
        private Task T;

        /// <summary>Status of the inner task of drawing</summary>
        public TaskStatus Status { get {
                return T != null ? T.Status : TaskStatus.WaitingForActivation; //Que belleza *chefs kiss*
            } 
        }

        /// <summary>Creates a Draw Thread</summary>
        public DrawThread() { 
            Handle = new AutoResetEvent(false);
            Tasks = new ConcurrentQueue<Task>();
        }

        /// <summary>Enqueues a task to the drawthread</summary>
        /// <param name="T"></param>
        public void AddDrawTask(Task T) { 
            Tasks.Enqueue(T);
            Handle.Set();
        }

        public void AddDrawTask(Action A) {
            if (CancelationPending) { throw new InvalidOperationException("You cannot add any more tasks if this thread is about to be cancelled"); }
            Tasks.Enqueue(new Task(A));
            Handle.Set();
        }

        /// <summary>Starts the drawthread</summary>
        public void Start() {
            if (T != null) { throw new InvalidOperationException("Drawthread is already running"); }
            T = new(() => Loop());
            T.Start();
        }

        /// <summary>Stops and resets the drawthread</summary>
        public void Stop() {
            CancelationPending = true;
            T.Wait();
            T = null;
            CancelationPending = false;
        }

        /// <summary>Main loop for the drawthread</summary>
        private void Loop() {
            while (!CancelationPending) {
                Handle.WaitOne();
                while (!Tasks.IsEmpty) {
                    if (Tasks.TryDequeue(out Task R)) { R.RunSynchronously(); }
                }
                Handle.Reset();
            }
        }

    }
}
