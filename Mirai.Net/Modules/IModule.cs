namespace Mirai.Net.Modules;

public interface IModule
{
    void Execute();
    bool? IsEnable { get; set; }
}