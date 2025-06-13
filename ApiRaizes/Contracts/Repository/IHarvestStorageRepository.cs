﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    interface IHarvestStorageRepository
    {
        Task<IEnumerable<HarvestStorageEntity>> GetAll();

        Task<HarvestStorageEntity> GetById(int id);

        Task Insert(HarvestStorageInsertDTO harvestStorage);

        Task Delete(int id);

        Task Update(HarvestStorageEntity harvestStorage);
    }
}
