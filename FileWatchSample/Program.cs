FileSystemWatcher watcher = new FileSystemWatcher();

try
{
    watcher.Path = ".../TestFolder";
}
catch (System.Exception exp)
{
    Console.WriteLine(exp.Message);
    return;
}

watcher.NotifyFilter = NotifyFilters.LastAccess 
| NotifyFilters.LastWrite 
| NotifyFilters.FileName 
| NotifyFilters.DirectoryName; 

watcher.Filter = "*.txt";

watcher.Changed += new FileSystemEventHandler(OnChanged);
watcher.Created += new FileSystemEventHandler(OnChanged);
watcher.Deleted += new FileSystemEventHandler(OnChanged);
watcher.Renamed += new RenamedEventHandler(OnRenamed);

watcher.EnableRaisingEvents = true;

static void OnChanged(Object source, FileSystemEventArgs e)
{
    Console.WriteLine("File: {0} {1} !", e.FullPath, e.ChangeType);
}

static void OnRenamed(Object source, RenamedEventArgs e)
{
    Console.WriteLine("File: {0} renamed to {1} !", e.OldFullPath, e.FullPath);
}

Console.ReadLine();

