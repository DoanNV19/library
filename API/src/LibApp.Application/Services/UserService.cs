using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;
using LibApp.Domain.Specifications;
using LibApp.Domain.Entities;
using LibApp.Domain.Enums;
using LibApp.Domain.Exceptions;
using LibApp.Application.Models.DTOs;
using LibApp.Application.Interfaces;
using LibApp.Application.Core.Services;
using LibApp.Domain.Core.Repositories;
using Mapster;

namespace LibApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _loggerService;

        public UserService(IUnitOfWork unitOfWork, ILoggerService loggerService)
        {
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
        }

        public async Task<UpdateUserRes> UpdateUserInfomation(UpdateUserReq req, string userId)
        {
            var userUpdate = await _unitOfWork.Repository<User>().GetByIdAsync(req.Id);
            userUpdate.FirstName = req.FirstName;
            userUpdate.LastName = req.LastName;
            userUpdate.EmailId = req.EmailId;
            _unitOfWork.Repository<User>().Update(userUpdate, userId);
            await _unitOfWork.SaveChangesAsync();
            _loggerService.LogInfo("New user update");
            return new UpdateUserRes() { Data = userUpdate.Adapt<UserDTO>() };
        }
    }
}