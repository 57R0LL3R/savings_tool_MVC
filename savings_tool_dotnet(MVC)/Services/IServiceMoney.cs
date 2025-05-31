using savings_tool_dotnet_MVC_.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace savings_tool_dotnet_MVC_.Services
{
    public interface IServiceMoney
    {
        public Task<List<Money>> ListMoney();

        public Task<List<Datum>> ListData();
        public Task UpdateData(Guid id, int val);
        public Task<Datum> FindData(Guid id);
        public Task<Money> FindMoney(Guid id);

        public Task AddMoney(Money m);
        public Task EditMoney(Guid id, int? q, double? v);

    }
}
