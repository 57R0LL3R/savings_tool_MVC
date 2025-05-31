using Microsoft.EntityFrameworkCore;
using savings_tool_dotnet_MVC_.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace savings_tool_dotnet_MVC_.Services
{

    public class ServiceMoney : IServiceMoney
    {
        List<Datum> datas;
        private readonly SavingsToolContext _Context;
        public ServiceMoney(SavingsToolContext context)
        {
            _Context = context;
            UpdateDatas();
        }
        public async Task<List<Money>> ListMoney()
        {
            return await _Context.Moneys.ToListAsync();
        }
        public List<Datum> UpdateDatas()
        {
            datas = _Context.Datas.ToList();
            return datas;
        }
        public async Task<List<Datum>> ListData()
        {
            UpdateDatas();
            return await _Context.Datas.ToListAsync(); ;
        }

        public async Task UpdateData(Guid id, int val)
        {
            var Data1 = (from Datum dat in _Context.Datas where dat.IdData == id select dat).FirstOrDefault();
            if (Data1 != null)
            {
                Data1.MaxValue = val;
                await _Context.SaveChangesAsync();
                UpdateDatas();
            }

        }

        public async Task<Datum> FindData(Guid id)
        {
            return await _Context.Datas.FindAsync(id);
        }

        public async Task<Money> FindMoney(Guid id)
        {
            return await _Context.Moneys.FindAsync(id);
        }

        public async Task AddMoney(Money m)
        {
            var Data1 = m;
            Data1.Days = 1;
            while (Data1.ValueMoney < datas[0].MaxValue && Data1.QuantityMoney < datas[1].MaxValue)
            {
                Data1.ValueMoney += Data1.ValueMoney / Data1.Days;
                Data1.QuantityMoney += Data1.QuantityMoney / Data1.Days;
                Data1.Days++;
            }
            await _Context.Moneys.AddAsync(m);
            await _Context.SaveChangesAsync();
        }

        public async Task EditMoney(Guid id, int? q, double? v)
        {
            var Data1 = (from Money dat in _Context.Moneys where dat.IdMoney == id select dat).FirstOrDefault();
            if (Data1 != null)
            {
                Data1.ValueMoney = v;
                Data1.QuantityMoney = q;
                Data1.Days = 1;
                while (Data1.ValueMoney < datas[0].MaxValue && Data1.QuantityMoney < datas[1].MaxValue)
                {
                    Data1.ValueMoney += Data1.ValueMoney / Data1.Days;
                    Data1.QuantityMoney += Data1.QuantityMoney / Data1.Days;
                    Data1.Days++;
                }
                await _Context.SaveChangesAsync();
            }
        }
    }
}
