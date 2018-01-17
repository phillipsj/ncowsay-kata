namespace cowsay.core {
    public interface ICowsay {
        string GetVersion();
        string GetCow(string message, Modes mode = Modes.Default);
    }
}
