using AutoMapper;
using AutoMapper.QueryableExtensions;
using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.LevelModel;
using FPLSP_TypingContest.Server.BLL.ViewModels.TextTemplate;
using FPLSP_TypingContest.Server.DAL.ApplicationDbContext;
using FPLSP_TypingContest.Server.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.Services.Implements
{
    public class TextTemplateServices : ITextTemplateServices
    {
        private readonly FPLSP_TypingContestDbContext _context;
        IMapper _mapper;
        public TextTemplateServices(IMapper mapper)
        {
            _context = new FPLSP_TypingContestDbContext();
            _mapper=mapper;
        }
        public async Task<bool> AddAsync( TextTemplateCreateVM request)
        {
            try
            {
                var TextTemplate = new TextTemplate()
                {
                    Id = new Guid(),
                    IdLevel = request.LevelId,
                    Title = request.Title,
                    Content = request.Content,
                    CreatedDate = DateTime.Now,
                    CreatedBy = request.CreatedBy,
                    Status = 0,
                    Level = _context.Levels.FirstOrDefault(p=>p.Id==request.LevelId)
                };
                await _context.TextTemplates.AddAsync(TextTemplate);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<TextTemplateVM>> GetAllActiveAsync()
        {
            var list = await _context.TextTemplates.ProjectTo<TextTemplateVM>(_mapper.ConfigurationProvider).Where(p=>p.Status!=1).ToListAsync();
            return list;
        }

        public async Task<List<TextTemplateVM>> GetAllAsync()
        {
            var list = await _context.TextTemplates.ProjectTo<TextTemplateVM>(_mapper.ConfigurationProvider).ToListAsync();
            return list;
        }

        public async Task<List<TextTemplateVM>> GetAllByLevelIdAsync(Guid LevelId)
        {
            var list = _context.TextTemplates.Where(p => p.IdLevel == LevelId && p.Status!=1).ProjectTo<TextTemplateVM>(_mapper.ConfigurationProvider);
            return await list.ToListAsync();
        }

        public async Task<TextTemplateVM> GetByIdAsync(Guid TextTemplateId)
        {
            var obj = await _context.TextTemplates.FindAsync(TextTemplateId);
            return _mapper.Map<TextTemplateVM>(obj);
        }

        public async Task<bool> RemoveAsync(Guid TextTemplateId, Guid DeleteBy)
        {
            var obj = _context.TextTemplates.FirstOrDefault(p=>p.Id==TextTemplateId);
            if (obj!=null)
            {
                obj.DeletedBy = DeleteBy;
                obj.Status = 1;
                obj.DeletedDate = DateTime.Now;
                _context.TextTemplates.Update(obj);
                await _context.SaveChangesAsync();
                return true;
            }return false;
        }

        public async Task<bool> UpdateAsync(Guid TextTemplateId, TextTemplateUpdateVM request)
        {
            var TextTemplate = _context.TextTemplates.FirstOrDefault(p => p.Id == TextTemplateId);
            if (TextTemplate != null)
            {
                TextTemplate.ModifiedDate = DateTime.Now;
                TextTemplate.Title = request.Title;
                TextTemplate.Content = request.Content;
                TextTemplate.ModifiedBy = request.ModifiedBy;
                TextTemplate.IdLevel = request.LevelId;
                TextTemplate.Level = _context.Levels.FirstOrDefault(p => p.Id == request.LevelId);

                _context.TextTemplates.Update(TextTemplate);
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
    }
}
