using AutoMapper;
using HiGeekNewsWebProject.Associate.VMs;
using HiGeekNewsWebProject.Business.Services.Abstract;
using HiGeekNewsWebProject.Business.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Business.Services.Concrete
{
    public class ShareService : IShareService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShareService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public JsonShareVM MakeShare(Guid id, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
