namespace ImgAbstractionLayer.Services
{
    public interface IApiParser
    {
        dynamic[] ParseApi(dynamic json);
    }
}
