using Observer.Exercise;

var downloader = new Downloader();

var progressDisplay = new ProgressDisplay();
var completionDisplay = new CompletionDisplay();

downloader.Subscribe(progressDisplay);
downloader.Subscribe(completionDisplay);

downloader.UpdateProgress(10);
downloader.UpdateProgress(50);
downloader.Unsubscribe(progressDisplay);

downloader.UpdateProgress(100);

var eventDownloader = new EventDownloader();
var progressPrinter = new ProgressPrinter();
var completionPrinter = new CompletionPrinter();

eventDownloader.ProgressChanged += progressPrinter.OnProgressChanged;
eventDownloader.ProgressChanged += completionPrinter.OnProgressChanged;

eventDownloader.UpdateProgress(10);
eventDownloader.UpdateProgress(50);
eventDownloader.UpdateProgress(50);

eventDownloader.ProgressChanged -= progressPrinter.OnProgressChanged;

eventDownloader.UpdateProgress(50);
eventDownloader.UpdateProgress(100);