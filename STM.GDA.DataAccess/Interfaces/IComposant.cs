
namespace STM.GDA.DataAccess
{
    public interface IComposant
    {
        int Id { get; }
        string Abreviation { get; }
        string Nom { get; }
        string Version { get; }
    }
}
