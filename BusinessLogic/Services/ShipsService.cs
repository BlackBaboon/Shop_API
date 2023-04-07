using Domain.Interfaces;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ShipService : IShipService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public ShipService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Ship>> GetAll()
        {
            return await _repositoryWrapper.Ship.FindAll();
        }
        public async Task<List<Ship>> GetById(int id)
        {
            var ship = _repositoryWrapper.Ship
            .FindByCondition(x => x.Id == id).Result;

            return ship;
        }
        public async Task Create(Ship model)
        {
            await _repositoryWrapper.Ship.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Ship model)
        {
            await _repositoryWrapper.Ship.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var ship = await _repositoryWrapper.Ship
            .FindByCondition(x => x.Id == id);

            await _repositoryWrapper.Ship.Delete(ship.First());
            await _repositoryWrapper.Save();
        }
    }
}
