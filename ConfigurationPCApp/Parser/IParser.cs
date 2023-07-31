namespace PCBuilderApp.Parser
{
    public interface IParser
    {

        public void StartedParseGPU();

        public void StartedParseCPU();

        public void StartedParseMotherboard();

        public void StartedParseRAM();

        public void StartedParsePSU();

        public void StartedParseCase();

    }
}
