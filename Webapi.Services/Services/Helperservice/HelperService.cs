using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppContext = Webapi.Data.Migrations.AppContext;
using Webapi.Services.Models;
using Webapi.Data.Entities;

namespace Webapi.Services.Services.Helperservice
{
    public class HelperService : IHelperService
    {
        private readonly AppContext _context;
        private readonly IMapper _mapper;

        public HelperService(AppContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public HelperDto AddHelper(HelperDto HelperDTO)
        {
            var helper = _mapper.Map<Helper>(HelperDTO);
            _context.helpers.Add(helper);
            _context.SaveChanges();
            return _mapper.Map<HelperDto>(helper);
        }

        public bool DeleteHelperById(int id)
        {
            var helperToDelete = _context.helpers.FirstOrDefault(h => h.HelperId == id);
            if (helperToDelete == null)
            {
                return false;
            }

            _context.helpers.Remove(helperToDelete);
            _context.SaveChanges();
            return true;
        }

        public List<HelperDto> GetAllHelpers(bool? IsActive)
        {
            var helpers = _context.helpers.ToList();
            return _mapper.Map<List<HelperDto>>(helpers);
        }

        public HelperDto GetHelperById(int id)
        {
            var helper = _context.helpers.FirstOrDefault(h => h.HelperId == id);
            return _mapper.Map<HelperDto>(helper);
        }

        public HelperDto UpdateHelper(int id, HelperDto HelperDTO)
        {
            var helperToUpdate = _context.helpers.FirstOrDefault(h => h.HelperId == id);
            if (helperToUpdate == null)
            {
                return null;
            }

            _mapper.Map(HelperDTO, helperToUpdate);
            _context.SaveChanges();

            return _mapper.Map<HelperDto>(helperToUpdate);
        }
        
    }
}
