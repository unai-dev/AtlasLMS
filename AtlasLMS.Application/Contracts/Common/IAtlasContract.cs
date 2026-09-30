namespace AtlasLMS.Application.Contracts.Common;

public interface IAtlasContract<TRead, TDetail, TCreate>
    where TRead : class
    where TDetail : class
    where TCreate : class
{
    Task<IEnumerable<TRead>> GetAll();
    Task<TRead> GetById(int ID);
    Task<TDetail> GetDetail(int ID);
    Task<TRead> Create(TCreate entity);
    Task Delete(int ID);
}
