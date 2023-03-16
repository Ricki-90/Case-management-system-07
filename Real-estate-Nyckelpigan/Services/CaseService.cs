using Real_estate_Nyckelpigan.Contexts;
using Real_estate_Nyckelpigan.Models.Entities;
using Real_estate_Nyckelpigan.Models;
using Microsoft.EntityFrameworkCore;

namespace Real_estate_Nyckelpigan.Services
{
    internal class CaseService
    {
        public static DataContext _context = new DataContext();
        public static async Task SaveAsync(CreateCase createCase)
        {

            var _RenterEntity = new RenterEntity
            {
                FirstName = createCase.FirstName,
                LastName = createCase.LastName,
                Email = createCase.Email,
                PhoneNumber = createCase.PhoneNumber,
            };

            var addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.StreetName == createCase.StreetName && x.PostalCode == createCase.PostalCode && x.City == createCase.City);
            if (addressEntity != null)
                _RenterEntity.AddressId = addressEntity.Id;

            else
                _RenterEntity.Address = new AddressEntity
                {
                    StreetName = createCase.StreetName,
                    PostalCode = createCase.PostalCode,
                    City = createCase.City,
                };

            var caseEntity = await _context.Cases.FirstOrDefaultAsync(x => x.Description == createCase.Description && x.Status == createCase.Status && x.IncomingDate == createCase.IncomingDate);
            if (caseEntity != null)
                _RenterEntity.CaseId = caseEntity.Id;

            else
                _RenterEntity.Case = new CaseEntity
                {
                    InternalCaseId = createCase.InternalCaseId,
                    Description = createCase.Description,
                    Status = createCase.Status,
                    IncomingDate = createCase.IncomingDate,
                };

            _context.Add(_RenterEntity);
            await _context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<CreateCase>> GetAllAsync()
        {
            var _createCases = new List<CreateCase>();

            foreach (var _createCase in await _context.Renters.Include(x => x.Case).ToListAsync())
                _createCases.Add(new CreateCase
                {
                    Id = _createCase.Id,
                    InternalCaseId = _createCase.Case.InternalCaseId,
                    Description = _createCase.Case.Description,
                    Status = _createCase.Case.Status,
                    IncomingDate = _createCase.Case.IncomingDate,
                    PropertyManagerComment = _createCase.Case.PropertyManagerComment
                });
            return _createCases;
        }

        public static async Task<CreateCase> GetAsync(string internalcaseid)
        {
            var _createCase = await _context.Renters.Include(x => x.Case).FirstOrDefaultAsync(x => x.Case.InternalCaseId == internalcaseid);
            if (_createCase != null)
                return new CreateCase
                {
                    Id = _createCase.Id,
                    InternalCaseId = _createCase.Case.InternalCaseId,
                    Description = _createCase.Case.Description,
                    Status = _createCase.Case.Status,
                    IncomingDate = _createCase.Case.IncomingDate,
                    PropertyManagerComment = _createCase.Case.PropertyManagerComment

                };
            else
                return null!;
        }

        public static async Task UpdateAsync(CreateCase UpdateCase)
        {

            var _caseEntity = await _context.Renters.Include(x => x.Case).FirstOrDefaultAsync(x => x.Case.InternalCaseId == UpdateCase.InternalCaseId);
            if (_caseEntity != null)
            {
                if (!string.IsNullOrEmpty(UpdateCase.Status))
                    _caseEntity.Case.Status = UpdateCase.Status;

                if (!string.IsNullOrEmpty(UpdateCase.PropertyManagerComment))
                    _caseEntity.Case.PropertyManagerComment = UpdateCase.PropertyManagerComment;

                _context.Update(_caseEntity);
                await _context.SaveChangesAsync();
            }
        }

        public static async Task DeleteAsync(string internalcaseid)
        {
            var createCase = await _context.Renters.Include(x => x.Address).Include(x => x.Case).FirstOrDefaultAsync(x => x.Case.InternalCaseId == internalcaseid);
            if (createCase != null)
            {
                _context.Remove(createCase);
                _context.Remove(createCase.Case);
                _context.Remove(createCase.Address);
                await _context.SaveChangesAsync();
            }
        }

        public static async Task<IEnumerable<CreateCase>> GetCaseRenterAsync()
        {
            var _createCases = new List<CreateCase>();

            foreach (var _createCase in await _context.Renters.Include(x => x.Case).Include(x => x.Address).ToListAsync())
                _createCases.Add(new CreateCase
                {
                    Id = _createCase.Id,
                    FirstName = _createCase.FirstName,
                    LastName = _createCase.LastName,
                    Email = _createCase.Email,
                    PhoneNumber = _createCase.PhoneNumber,
                    StreetName = _createCase.Address.StreetName,
                    PostalCode = _createCase.Address.PostalCode,
                    City = _createCase.Address.City,
                    CaseId = _createCase.CaseId,
                    InternalCaseId = _createCase.Case.InternalCaseId
                });
            return _createCases;
        }
    }
}
