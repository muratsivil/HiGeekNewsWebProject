namespace HiGeekNewsWebProject.Business.Services.Concrete
{
    internal interface IUnitOfWork
    {
        object Share { get; }
    }
}