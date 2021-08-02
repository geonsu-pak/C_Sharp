public async Task MyMethodAsync()
{
    Task<int> longRunningTask = LongRunningOperationAsync();

    // MyMethodAsync will return
    int result = await longRunningTask;
    // MyMethodAsync resume
  
    Console.WriteLine(result);
}

// assume we return an int from this long running operation 
public async Task<int> LongRunningOperationAsync() 
{
    await Task.Delay(1000); // 1 second delay
    return 1;
}
//--------------------------------------------------------------
Console.WriteLine(DateTime.Now);

// This block takes 1 second to run because all
// 5 tasks are running simultaneously
{
    var a = Task.Delay(1000);
    var b = Task.Delay(1000);
    var c = Task.Delay(1000);
    var d = Task.Delay(1000);
    var e = Task.Delay(1000);

    await a;
    await b;
    await c;
    await d;
    await e;
}

Console.WriteLine(DateTime.Now);

// This block takes 5 seconds to run because each "await"
// pauses the code until the task finishes
{
    await Task.Delay(1000);
    await Task.Delay(1000);
    await Task.Delay(1000);
    await Task.Delay(1000);
    await Task.Delay(1000);
}
Console.WriteLine(DateTime.Now);
//--------------------------------------------------------------
Further to the other answers, have a look at await (C# Reference)
and more specifically at the example included, it explains your situation a bit

The following Windows Forms example illustrates the use of await in an async method, WaitAsynchronouslyAsync. 
Contrast the behavior of that method with the behavior of WaitSynchronously. 
Without an await operator applied to a task, WaitSynchronously runs synchronously 
despite the use of the async modifier in its definition and a call to Thread.Sleep in its body.

private async void button1_Click(object sender, EventArgs e)
{
    // Call the method that runs asynchronously.
    string result = await WaitAsynchronouslyAsync();

    // Call the method that runs synchronously.
    //string result = await WaitSynchronously ();

    // Display the result.
    textBox1.Text += result;
}

// The following method runs asynchronously. The UI thread is not
// blocked during the delay. You can move or resize the Form1 window 
// while Task.Delay is running.
public async Task<string> WaitAsynchronouslyAsync()
{
    await Task.Delay(10000);
    return "Finished";
}

// The following method runs synchronously, despite the use of async.
// You cannot move or resize the Form1 window while Thread.Sleep
// is running because the UI thread is blocked.
public async Task<string> WaitSynchronously()
{
    // Add a using directive for System.Threading.
    Thread.Sleep(10000);
    return "Finished";
}

