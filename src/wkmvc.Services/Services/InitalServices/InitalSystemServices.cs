using System;
using System.Threading.Tasks;
using wkmvc.Core;
using wkmvc.Core.IServices;
using wkmvc.Data.Models;

namespace wkmvc.Services.InitalServices
{
    public class InitalSystemServices
    {
        private readonly IUserService _userService;
        private readonly IModuleService _moduleService;
        private readonly IUnitOfWork _unitOfWork;

        public InitalSystemServices(IUserService userService, IModuleService moduleService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _moduleService = moduleService;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 初始化系统
        /// </summary>
        /// <returns></returns>
        public async Task<bool> InitalSystem()
        {
            var IsExitUsersAsync = _userService.IsExistAsync(p => p.ID > 0);
            var IsExitModulesAsync = _moduleService.IsExistAsync(p => p.ID > 0);           

            var InitUsersAsync = _userService.SaveAsync(new SYS_USER()
            {
                UserName = "超级管理员",
                EN_Name = "Admins",
                EN_Nme_Simple = "Admins",
                Account = "admins",
                Password = new Common.CryptHelper.AESCrypt().Encrypt("Yuan19880212"),
                IsCanLogin = true,
                CreateDate = DateTime.Now,
                CreateUser = "系统初始化",
                UpdateDate = DateTime.Now,
                UpdateUser = "系统初始化",
                IsSuper = true,
                UserOnline = new SYS_USER_ONLINE() { IsOnlie = false, OffLineDate = DateTime.Now, OnlineDate = DateTime.Now }
            }, false);

            var InitModulesAsync = _moduleService.SaveAsync(new SYS_MODULE()
            {
                SystemID = "",
                ParentID = 0,
                Name = "系统管理",
                Alias = "SystemSpace",
                ModuleType = 1,
                IsDisplay = true,
                DisplayOrder = 0,
                Levels = 0,
                CreateUser = "系统初始化",
                UpdateDate = DateTime.Now,
                UpdateUser = "系统初始化"
            }, false);

            bool IsExitUsers = await IsExitUsersAsync;
            bool IsExitModules = await IsExitModulesAsync;

            if (!IsExitUsers) { bool InitUsers = await InitUsersAsync; }
            if (!IsExitModules) { bool InitModules = await InitModulesAsync; }

            return await Task.Run(() => _unitOfWork.Commit());
        }
    }
}
