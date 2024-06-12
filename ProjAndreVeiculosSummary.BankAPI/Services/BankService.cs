using Models;
using MongoDB.Driver;
using ProjAndreVeiculosSummary.BankAPI.Utils;

namespace ProjAndreVeiculosSummary.BankAPI.Services
{
    public class BankService
    {
        private readonly IMongoCollection<Bank> _bank;

        public BankService(IProjAndreVeiculosSummarySettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _bank = database.GetCollection<Bank>(settings.BankCollectionName);
        }

        public List<Bank> GetBanks() =>
            _bank.Find(bank => true).ToList();

        public Bank Create(Bank bank)
        {
            _bank.InsertOne(bank);
            return bank;
        }

        //public Bank Get(string id) =>
        //    _bank.Find<Bank>(bank => bank.Id == id).FirstOrDefault();

        //public void Update(string id, Bank bankIn) =>
        //    _banks.ReplaceOne(bank => bank.Id == id, bankIn);

        //public void Remove(Bank bankIn) =>
        //    _banks.DeleteOne(bank => bank.Id == bankIn.Id);

        //public void Remove(string id) =>
        //    _banks.DeleteOne(bank => bank.Id == id);
    }
}
