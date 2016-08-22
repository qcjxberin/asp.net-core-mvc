
Core类库：应用服务类库

\.. Repository 存放仓储、工作单元应用服务

		IRepository.cs：仓储接口
		Repository.cs：仓储实现类
		IUnitOfWork.cs：工作单元接口
		UnitOfWork：工作单元实现类


\.. Services 存放应用服务

		\.. SysServices：存放系统应用服务

			\.. IServices：存放系统应用服务接口

					IUserService.cs：系统用户接口				

			\.. ServicesImp：存放系统应用服务实现类

					UserService.cs：系统用户实现类