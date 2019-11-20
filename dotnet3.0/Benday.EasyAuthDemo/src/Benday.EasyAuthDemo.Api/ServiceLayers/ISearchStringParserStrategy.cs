namespace Benday.EasyAuthDemo.Api.ServiceLayers
{
    public interface ISearchStringParserStrategy
    {
        string[] Parse(string parseThis);
    }
}