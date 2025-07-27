﻿using ApiCoreHospitales.Data;
using ApiCoreHospitales.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreHospitales.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;
        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }
        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            return await this.context.Hospitales.ToListAsync();
        }
        public async Task<Hospital> FindHospitalAsync(int idHospital)
        {
            return await this.context.Hospitales
                .FirstOrDefaultAsync(x => x.IdHospital == idHospital);
        }
    }
}
