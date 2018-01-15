namespace cowsay.core {
    public interface ICowsay {
        string Version();
        string SayMessage(string message);
    }
}
