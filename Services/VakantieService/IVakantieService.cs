﻿using HRSystem.Dtos.Vakantie;

namespace HRSystem.Services.VakantieService
{
    public interface IVakantieService
    {
        Task<ServiceResponse<List<GetVakantieDto>>> GetAllVakantie();
        Task<ServiceResponse<GetVakantieDto>> GetVakantieById(int id);
        Task<ServiceResponse<List<GetVakantieDto>>> AddVakantie(AddVakantieDto newVakantie);
        Task<ServiceResponse<GetVakantieDto>> UpdateVakantie(UpdateVakantieDto updatedVakantie);
        Task<ServiceResponse<List<GetVakantieDto>>> DeleteVakantie(int id);
        Task<ServiceResponse<GetVakantieDto>> updateGoedKeruing(UpdateVakantieDto updatedVakantie);
    }
}
