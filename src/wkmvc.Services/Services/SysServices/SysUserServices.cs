using System;
using System.Threading.Tasks;
using wkmvc.Core;
using wkmvc.Core.IServices;
using wkmvc.Data.Models;

namespace wkmvc.Services.SysServices
{
    public class SysUserServices
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        

        public SysUserServices(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;           
        }
      
    }
}
